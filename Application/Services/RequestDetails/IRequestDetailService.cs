using Application.Services.RequestDetails.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.RequestDetails
{
    public interface IRequestDetailService
    {
        Task Create(CreateRequestDetailDto input);
        Task<GetRequestDetailDto> GetByRequestId(Guid requestId);
    }
}
