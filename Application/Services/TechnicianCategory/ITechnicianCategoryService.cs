using Application.Services.TechnicianCategory.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.TechnicianCategory
{
    public interface ITechnicianCategoryService
    {
        Task Assign(AssignTechnicianCategoryDto input);
        Task<List<GetTechnicianCategoryDto>> GetAll();
    }
}
