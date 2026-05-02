using Application.Reposetories;
using Application.Services.RoleService.DTOs;
using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace Application.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IGenericRepository<Role> _repo;

        public RoleService(IGenericRepository<Role> repo)
        {
            _repo = repo;
        }

        public async Task Create(CreateRoleDto input)
        {
            var role = new Role
            {
                Id = Guid.NewGuid(),
                Name = input.Name,
                Code = input.Code
            };

            await _repo.InsertAsync(role);
            await _repo.SaveChangesAsync();
        }

        public async Task<List<GetRoleDto>> GetAll()
        {
            return await _repo.GetAll()
                .Select(x => new GetRoleDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Code = x.Code
                }).ToListAsync();
        }
    }
}
