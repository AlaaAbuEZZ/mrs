using Application.Services.RequestDetailService.DTOs;

namespace Application.Services.RequestDetailService
{
    public interface IRequestDetailService
    {
        Task Create(CreateRequestDetailDto input);
        Task<List<GetRequestDetailDto>> GetAll();
        Task<GetRequestDetailDto> GetByRequestId(Guid requestId);
    }
}