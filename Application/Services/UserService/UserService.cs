using Application.Reposetories;
using Application.Services.UserService.Dtos;
using Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepo;
        private readonly IGenericRepository<Role> _roleRepo;

        public UserService(
            IGenericRepository<User> userRepo,
            IGenericRepository<Role> roleRepo)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
        }

        // ================= CREATE USER =================
        public async Task CreateUser(CreateUserDto input)
        {
            input.Email = input.Email.ToLower().Trim();

            var exist = await _userRepo.GetAll()
                .AnyAsync(x => x.Email == input.Email);

            if (exist)
                throw new Exception("Email already exists");

            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = input.Name,
                Email = input.Email,
                PhonNumber = input.PhoneNumber,
                RoleId = input.RoleId
            };

            var hasher = new PasswordHasher<User>();
            user.Password = hasher.HashPassword(user, input.Password);

            await _userRepo.InsertAsync(user);
            await _userRepo.SaveChangesAsync();
        }

        // ================= GET ALL =================
        public async Task<List<GetListUserDto>> GetAll(string? name, string? email)
        {
            var query = _userRepo.GetAll()
                .Include(x => x.Role)
                .AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                name = name.ToLower().Trim();
                query = query.Where(x => x.Name.ToLower().Contains(name));
            }

            if (!string.IsNullOrEmpty(email))
            {
                email = email.ToLower().Trim();
                query = query.Where(x => x.Email.ToLower().Contains(email));
            }

            return await query.Select(x => new GetListUserDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                RoleName = x.Role.Name
            }).ToListAsync();
        }

        // ================= GET BY ID =================
        public async Task<GetUserDto> GetById(Guid id)
        {
            var user = await _userRepo.GetAll()
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                throw new Exception("User not found");

            return new GetUserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhonNumber,
                RoleName = user.Role.Name
            };
        }

        // ================= UPDATE =================
        public async Task Update(UpdateUserDto input)
        {
            var user = await _userRepo.GetByIdAsync(input.Id);

            if (user == null)
                throw new Exception("User not found");

            user.Name = input.Name;
            user.PhonNumber = input.PhoneNumber;

            await _userRepo.UpdateAsync(user);
            await _userRepo.SaveChangesAsync();
        }

        // ================= DELETE =================
        public async Task Delete(Guid id)
        {
            var user = await _userRepo.GetByIdAsync(id);

            if (user == null)
                throw new Exception("User not found");

            _userRepo.Delete(user);
            await _userRepo.SaveChangesAsync();
        }
    }
}