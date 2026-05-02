using Application.Services.RequestHistory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestHistoryController : ControllerBase
    {
        private readonly IRequestHistoryService _service;

        public RequestHistoryController(IRequestHistoryService service)
        {
            _service = service;
        }
        [Authorize]
        [HttpGet("{requestId}")]
        public async Task<IActionResult> GetByRequest(Guid requestId)
        {
            return Ok(await _service.GetByRequestId(requestId));
        }
    }
}