using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.RequestService.RequestDTOs
{
    public class AssignRequestDto
    {
        public Guid RequestId { get; set; }
        public Guid TechnicianId { get; set; }
    }
}
