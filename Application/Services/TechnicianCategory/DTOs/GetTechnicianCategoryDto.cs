using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.TechnicianCategory.DTOs
{
    public class GetTechnicianCategoryDto
    {
        public Guid TechnicianId { get; set; }
        public string TechnicianName { get; set; }
        public string CategoryName { get; set; }
    }
}
