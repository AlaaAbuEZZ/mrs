using Application.Services.AuthService;
using Application.Services.AuthService.DTOs;
using Domain.Entites;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthService _authService;

        public TokenController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh(RefreshTokenDto input)
        {
            var result = await _authService.RefreshToken(input);
            return Ok(result);
        }

        [HttpPost("GenerateToken")]
        public IActionResult Generate(User user)
        {
            var result = _authService.GenerateAccessToken(user);
            return Ok(result);
        }

    }
}