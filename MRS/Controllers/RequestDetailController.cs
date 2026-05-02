using Application.Services.RequestDetailService;
using Application.Services.RequestDetailService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RequestDetailController : ControllerBase
    {
        private readonly IRequestDetailService _service;

        public RequestDetailController(IRequestDetailService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CreateRequestDetailDto input)
        {
            await _service.Create(input);
            return Ok("Created");
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("get-by-request/{id}")]
        public async Task<IActionResult> GetByRequest(Guid id)
        {
            return Ok(await _service.GetByRequestId(id));
        }
    }
}