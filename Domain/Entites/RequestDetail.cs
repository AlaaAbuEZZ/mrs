using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites
{
    [Index(nameof(RequestId),IsUnique =true)]
    public class RequestDetail
    {
        public Guid Id { get; set; }
        public string Location { get; set; }
        public string EmployeeNote { get; set; }
        public string TechnicianNote { get; set; }
        public Guid RequestId { get; set; }
        [ForeignKey("RequestId")]
        public Request Request { get; set; }
        public string? PhotoURL { get; set; }

    }
}
