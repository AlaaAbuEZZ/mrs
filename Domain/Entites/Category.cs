using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Domain.Entites
{
    public class Category
    {
        // test comment
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
