using Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites
{
    public class Request
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Guid EmployeeId { get; set; }
        [ForeignKey(nameof(EmployeeId))]
        public User Employee { get; set; }

        public Guid? TechnicianId { get; set; }
        [ForeignKey(nameof(TechnicianId))]
        public User Technician { get; set; }


        public Guid CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        public string Location { get; set; }
        public RequestStatus status { get; set; } = RequestStatus.New;
        public DateTime CreatedAt { get; set; }

    }
}
