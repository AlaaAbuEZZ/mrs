using Application.Reposetories;
using Application.Services.CategoryService.CategoryDTOs;

using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _repo;

        public CategoryService(IGenericRepository<Category> repo)
        {
            _repo = repo;
        }

        public async Task Create(CreateCategoryDto input)
        {
            var data = new Category
            {
                Id = Guid.NewGuid(),
                Name = input.Name
            };

            await _repo.InsertAsync(data);
            await _repo.SaveChangesAsync();
        }

        public async Task<List<GetCategoryDto>> GetAll()
        {
            return await _repo.GetAll()
                .Select(x => new GetCategoryDto
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToListAsync();
        }
    }
}