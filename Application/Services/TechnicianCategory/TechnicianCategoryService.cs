using Application.Reposetories;
using Application.Services.TechnicianCategory.DTOs;
using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.TechnicianCategory
{
    public class TechnicianCategoryService : ITechnicianCategoryService
    {
        private readonly IGenericRepository<Domain.Entites.TechnicianCategory> _repo;

        public TechnicianCategoryService(IGenericRepository<Domain.Entites.TechnicianCategory> repo)
        {
            _repo = repo;
        }

        public async Task Assign(AssignTechnicianCategoryDto input)
        {
            var data = new Domain.Entites.TechnicianCategory
            {
                Id = Guid.NewGuid(),
                TechnicianId = input.TechnicianId,
                CategoryId = input.CategoryId
            };

            await _repo.InsertAsync(data);
            await _repo.SaveChangesAsync();
        }

        public async Task<List<GetTechnicianCategoryDto>> GetAll()
        {
            return await _repo.GetAll()
                .Include(x => x.Technician)
                .Include(x => x.Category)
                .Select(x => new GetTechnicianCategoryDto
                {
                    TechnicianId = x.TechnicianId,
                    TechnicianName = x.Technician != null ? x.Technician.Name : null,
                    CategoryName = x.Category != null ? x.Category.Name : null
                })
                .ToListAsync();
        }
    }
}