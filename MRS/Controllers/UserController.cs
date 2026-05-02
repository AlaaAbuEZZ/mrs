using Application.Services.UserService;
using Application.Services.UserService.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll(string? name, string? email)
        {
            var result = await _userService.GetAll(name, email);
            return Ok(result);
        }

        [Authorize]
        [HttpGet("GetUsersbyid")]
        public async Task<IActionResult> GetUsersbyid(Guid id)
        {
            var user = await _userService.GetById(id);
            return Ok(user);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto input)
        {
            await _userService.CreateUser(input);
            return Ok("User Created");
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}