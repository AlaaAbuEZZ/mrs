using Application.Reposetories;
using Application.Services.AuthService.DTOs;
using Application.Services.CurrentUserService;
using Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Application.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<Domain.Entites.Token> _tokenRepository;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;

        public AuthService(
            IGenericRepository<User> userRepository,
            IConfiguration configuration,
            IGenericRepository<Domain.Entites.Token> tokenRepository,
            ICurrentUserService currentUserService)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _tokenRepository = tokenRepository;
            _currentUserService = currentUserService;
        }

        // =========================
        // LOGIN
        // =========================
        public async Task<LoginResponseDto> Login(LoginRequestDto input)
        {
            var user = await _userRepository.GetAll()
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x =>
                    x.Email == input.UserName.ToLower().Trim()
                    || x.PhonNumber == input.UserName.Trim());

            if (user == null)
                throw new Exception("Invalid username or password");

            var hasher = new PasswordHasher<User>();
            var result = hasher.VerifyHashedPassword(user, user.Password, input.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new Exception("Invalid username or password");

            var accessToken = GenerateAccessToken(user);
            var refreshToken = GenerateRefreshToken();

            await _tokenRepository.InsertAsync(new Domain.Entites.Token
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                TokenStr = refreshToken,
                ExpiaryDate = DateTime.UtcNow.AddDays(7)
            });

            await _tokenRepository.SaveChangesAsync();

            return new LoginResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhonNumber,
                RoleName = user.Role.Name,
                RoleCode = user.Role.Code,
                AccessToken = accessToken,
                RefershToken = refreshToken
            };
        }

        // =========================
        // REFRESH TOKEN
        // =========================
        public async Task<LoginResponseDto> RefreshToken(RefreshTokenDto input)
        {
            var token = await _tokenRepository.GetAll()
                .Include(x => x.User)
                .ThenInclude(x => x.Role)
                .FirstOrDefaultAsync(x =>
                    x.TokenStr == input.Token &&
                    x.ExpiaryDate > DateTime.UtcNow);

            if (token == null)
                throw new Exception("Invalid or expired refresh token");

            var user = token.User;

            var newAccessToken = GenerateAccessToken(user);
            var newRefreshToken = GenerateRefreshToken();

            token.TokenStr = newRefreshToken;
            token.ExpiaryDate = DateTime.UtcNow.AddDays(7);

            await _tokenRepository.UpdateAsync(token);
            await _tokenRepository.SaveChangesAsync();

            return new LoginResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhonNumber,
                RoleName = user.Role.Name,
                RoleCode = user.Role.Code,
                AccessToken = newAccessToken,
                RefershToken = newRefreshToken
            };
        }

        // =========================
        // CHANGE PASSWORD
        // =========================
        public async Task ChangeUserPassword(ChangeUserPasswordDto input)
        {
            var userId = _currentUserService.UserId;

            var user = await _userRepository.GetByIdAsync(userId.Value);

            var hasher = new PasswordHasher<User>();
            var check = hasher.VerifyHashedPassword(user, user.Password, input.CurrentPassword);

            if (check == PasswordVerificationResult.Failed)
                throw new Exception("Current password is incorrect");

            if (input.NewPassword != input.ConfirmNewPassword)
                throw new Exception("Passwords do not match");

            user.Password = hasher.HashPassword(user, input.NewPassword);

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();
        }

        // =========================
        // JWT GENERATION
        // =========================
        public  string GenerateAccessToken(User user)
        {
            var jwt = _configuration.GetSection("Jwt");

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwt["Key"]));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.MobilePhone, user.PhonNumber),
                new Claim(ClaimTypes.Role, user.Role.Code.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwt["Issuer"],
                audience: jwt["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // =========================
        // REFRESH TOKEN GENERATOR
        // =========================
        private string GenerateRefreshToken()
        {
            var bytes = new byte[64];
            RandomNumberGenerator.Fill(bytes);
            return Convert.ToBase64String(bytes);
        }

       
    }
}