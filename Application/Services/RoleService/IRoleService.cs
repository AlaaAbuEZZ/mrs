using Application.Services.RoleService.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.RoleService
{
    public interface IRoleService
    {
        Task Create(CreateRoleDto input);
        Task<List<GetRoleDto>> GetAll();
    }
}
