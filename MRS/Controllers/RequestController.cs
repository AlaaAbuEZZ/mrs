using Application.Services.RequestService;

using Application.Services.RequestService.RequestDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateRequestDto input)
        {
            await _requestService.Create(input);
            return Ok();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _requestService.GetAll());
        }
        [Authorize]
        [HttpPut("change-status")]
        public async Task<IActionResult> ChangeStatus(ChangeStatusDto input)
        {
            await _requestService.ChangeStatus(input);
            return Ok();
        }
    }
}