using Application.Reposetories;
using Application.Services.RequestDetails.DTOs;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace Application.Services.RequestDetails
{
    public class RequestDetailService : IRequestDetailService
    {
        private readonly IGenericRepository<RequestDetail> _repo;

        public RequestDetailService(IGenericRepository<RequestDetail> repo)
        {
            _repo = repo;
        }

        public async Task Create(CreateRequestDetailDto input)
        {
            var data = new RequestDetail
            {
                Id = Guid.NewGuid(),
                RequestId = input.RequestId,
                Location = input.Location,
                EmployeeNote = input.EmployeeNote,
                PhotoURL = input.PhotoURL
            };

            await _repo.InsertAsync(data);
            await _repo.SaveChangesAsync();
        }

        public async Task<GetRequestDetailDto> GetByRequestId(Guid requestId)
        {
            var data = await _repo.GetAll()
                .FirstOrDefaultAsync(x => x.RequestId == requestId);

            return new GetRequestDetailDto
            {
                Location = data.Location,
                EmployeeNote = data.EmployeeNote,
                TechnicianNote = data.TechnicianNote,
                PhotoURL = data.PhotoURL
            };
        }
    }
}
