using Application.Reposetories;
using Application.Services.RequestDetailService.DTOs;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.RequestDetailService
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
            var entity = new RequestDetail
            {
                Id = Guid.NewGuid(),
                RequestId = input.RequestId,
                Location = input.Location,
                EmployeeNote = input.EmployeeNote,
                PhotoURL = input.PhotoURL,
                TechnicianNote = ""
            };

            await _repo.InsertAsync(entity);
            await _repo.SaveChangesAsync();
        }

        public async Task<List<GetRequestDetailDto>> GetAll()
        {
            return await _repo.GetAll()
                .Select(x => new GetRequestDetailDto
                {
                    Id = x.Id,
                    RequestId = x.RequestId,
                    Location = x.Location,
                    EmployeeNote = x.EmployeeNote,
                    TechnicianNote = x.TechnicianNote,
                    PhotoURL = x.PhotoURL
                })
                .ToListAsync();
        }

        public async Task<GetRequestDetailDto> GetByRequestId(Guid requestId)
        {
            return await _repo.GetAll()
                .Where(x => x.RequestId == requestId)
                .Select(x => new GetRequestDetailDto
                {
                    Id = x.Id,
                    RequestId = x.RequestId,
                    Location = x.Location,
                    EmployeeNote = x.EmployeeNote,
                    TechnicianNote = x.TechnicianNote,
                    PhotoURL = x.PhotoURL
                })
                .FirstOrDefaultAsync();
        }
    }
}