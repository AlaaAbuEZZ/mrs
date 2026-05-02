using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.RequestHistory.DTOs
{
    public class GetRequestHistoryDto
    {
        public string UserName { get; set; }
        public string OldStatus { get; set; }
        public string NewStatus { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
