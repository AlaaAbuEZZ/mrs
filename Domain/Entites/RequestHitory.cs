using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entites
{
    public class RequestHitory
    {
        public Guid Id { get; set; }

        
      public  Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public Guid RequestId { get; set; }
        [ForeignKey("RequestId")]
        public Request Request { get; set; }

        public RequestStatus? OldStatus { get; set; }
        public RequestStatus? NewStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? Comment { get; set; }
    }
}
