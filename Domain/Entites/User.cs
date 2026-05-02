using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entites
{
   
    public class User
    {
       
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhonNumber { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        public String? Location { get; set; }


    }
}
