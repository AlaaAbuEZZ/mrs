using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.RequestService.RequestDTOs
{
    public class ChangeStatusDto
    {
        public Guid RequestId { get; set; }
        public RequestStatus Status { get; set; }
        public string? Note { get; set; }
    }
}
