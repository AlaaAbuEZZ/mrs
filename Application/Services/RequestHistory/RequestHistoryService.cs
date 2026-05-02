using Application.Reposetories;
using Application.Services.RequestHistory.DTOs;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;


namespace Application.Services.RequestHistory
{
    public class RequestHistoryService : IRequestHistoryService
    {
        private readonly IGenericRepository<RequestHitory> _repo;

        public RequestHistoryService(IGenericRepository<RequestHitory> repo)
        {
            _repo = repo;
        }

        public async Task<List<GetRequestHistoryDto>> GetByRequestId(Guid requestId)
        {
            return await _repo.GetAll()
                .Where(x => x.RequestId == requestId)
                .Include(x => x.User)
                .Select(x => new GetRequestHistoryDto
                {
                    UserName = x.User.Name,
                    OldStatus = x.OldStatus.ToString(),
                    NewStatus = x.NewStatus.ToString(),
                    Comment = x.Comment,
                    CreatedAt = x.CreatedAt
                }).ToListAsync();
        }
    }
}
