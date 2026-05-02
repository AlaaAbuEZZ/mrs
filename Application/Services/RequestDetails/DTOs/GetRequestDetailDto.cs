using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.RequestDetails.DTOs
{
    public class GetRequestDetailDto
    {
        public string Location { get; set; }
        public string EmployeeNote { get; set; }
        public string TechnicianNote { get; set; }
        public string? PhotoURL { get; set; }
    }
}
