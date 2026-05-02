using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.RequestService.RequestDTOs
{
    public class GetRequestDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string EmployeeName { get; set; }
        public string? TechnicianName { get; set; }

        public string CategoryName { get; set; }
        public string Location { get; set; }

        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
