using Application.Services.CategoryService.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.CategoryService
{
    public interface ICategoryService
    {
        Task Create(CreateCategoryDto input);
        Task<List<GetCategoryDto>> GetAll();
    }
}
