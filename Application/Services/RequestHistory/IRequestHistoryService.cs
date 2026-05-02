using Application.Services.RequestHistory.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.RequestHistory
{
    public interface IRequestHistoryService
    {
        Task<List<GetRequestHistoryDto>> GetByRequestId(Guid requestId);
    }
}
