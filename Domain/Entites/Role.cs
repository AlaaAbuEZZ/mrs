using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entites
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public SystemRole Code { get; set; }


    }
}
