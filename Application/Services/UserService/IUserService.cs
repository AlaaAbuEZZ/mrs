using Application.Services.UserService.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.UserService
{
    public interface IUserService

    {
        Task CreateUser(CreateUserDto input);
        Task<List<GetListUserDto>> GetAll(string? name, string? email);
        Task<GetUserDto> GetById(Guid id);
        Task Update(UpdateUserDto input);
        Task Delete(Guid id);

    }
}
