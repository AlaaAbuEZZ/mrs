using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.RoleService.DTOs
{
    public class CreateRoleDto
    {
        public string Name { get; set; }
        public SystemRole Code { get; set; }
    }

    public class GetRoleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public SystemRole Code { get; set; }
    }
}
