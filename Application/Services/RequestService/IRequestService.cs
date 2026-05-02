using Application.Services.RequestService.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.RequestService
{
    public interface IRequestService
    {
        Task CreateRequest(CreateRequestDto input);
        Task<List<GetRequestDto>> GetAll();
        Task AssignRequest(AssignRequestDto input);
        Task ChangeStatus(ChangeStatusDto input);
        Task Create(CreateRequestDto input);
    }
}
