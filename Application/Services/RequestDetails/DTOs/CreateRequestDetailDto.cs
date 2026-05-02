using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.RequestDetails.DTOs
{
    public class CreateRequestDetailDto
    {
        public Guid RequestId { get; set; }
        public string Location { get; set; }
        public string EmployeeNote { get; set; }
        public string? PhotoURL { get; set; }
    }
}
