using Application.Services.AuthService;
using Application.Services.AuthService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ApiProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // 🔐 Login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto input)
        {
            var result = await _authService.Login(input);
            return Ok(result);
        }

        // 🔄 Refresh Token
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenDto input)
        {
            var token = await _authService.RefreshToken(input);

            if (token == null)
                return Unauthorized("Invalid refresh token");

            return Ok(token);
        }

        // 🔑 Change Password
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangeUserPasswordDto input)
        {
            await _authService.ChangeUserPassword(input);
            return Ok("Password changed successfully");
        }
    }
}