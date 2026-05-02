using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.TechnicianCategory.DTOs
{
    public class AssignTechnicianCategoryDto
    {
        public Guid TechnicianId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
