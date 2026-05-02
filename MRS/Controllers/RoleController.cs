using Application.Services.RoleService;

using Application.Services.RoleService.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _roleService.GetAll());
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleDto input)
        {
            await _roleService.Create(input);
            return Ok();
        }
    }
}