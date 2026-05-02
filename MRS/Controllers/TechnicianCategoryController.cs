using Application.Services.TechnicianCategory;
using Application.Services.TechnicianCategory.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicianCategoryController : ControllerBase
    {
        private readonly ITechnicianCategoryService _service;

        public TechnicianCategoryController(ITechnicianCategoryService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpPost("assign")]
        public async Task<IActionResult> Assign(AssignTechnicianCategoryDto input)
        {
            await _service.Assign(input);
            return Ok();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }
    }
}