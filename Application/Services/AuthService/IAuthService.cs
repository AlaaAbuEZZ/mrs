using Application.Services.AuthService.DTOs;
using Domain.Entites;

namespace Application.Services.AuthService
{
    public interface IAuthService
    {
        Task<LoginResponseDto> Login(LoginRequestDto input);

        Task<LoginResponseDto> RefreshToken(RefreshTokenDto input);

        Task ChangeUserPassword(ChangeUserPasswordDto input);

        string GenerateAccessToken(User user);
    }
}