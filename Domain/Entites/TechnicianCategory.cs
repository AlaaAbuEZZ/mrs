using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entites
{
    public class TechnicianCategory
    {
        public Guid Id { get; set; }

        public Guid TechnicianId { get; set; }
        [ForeignKey(nameof(TechnicianId))]
        public User Technician { get; set; }


        public Guid CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}
