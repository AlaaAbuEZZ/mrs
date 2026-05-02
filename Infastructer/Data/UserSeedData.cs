using Domain.Entites;

using Domain.Enum;
using Infastructer.Context;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data
{
    public static class UserSeedData
    {
        private static readonly string adminPassword = "Admin@123";

        public static void Seed(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            context.Database.Migrate();

            // Seed Roles
            if (!context.Roles.Any() || 1==1)
            {
                var roles = new List<Role>
                {
                    new Role { Name = SystemRole.Admin.ToString(), Code = SystemRole.Admin },
                    new Role { Name = SystemRole.Technician.ToString(), Code = SystemRole.Technician },
                    new Role { Name = SystemRole.Employee.ToString(), Code = SystemRole.Employee }
                };

                context.Roles.AddRange(roles);
                context.SaveChanges();
            }

            // Seed Admin User
            if (!context.Users.Any())
            {
                var adminRoleId = context.Roles.First(r => r.Code == SystemRole.Admin).Id;

                var User = new User
                {
                    Name = "Admin User",
                    Email = "admin@example.com",
                    PhonNumber = "0000000000",
                    RoleId = adminRoleId,
                    //password = HashPassword(adminPassword)
                };

                var passwordHasher = new PasswordHasher<User>();
                User.Password = passwordHasher.HashPassword(User, adminPassword);

                context.Users.Add(User);
                context.SaveChanges();
            }
        }

        //private static string HashPassword(string password)
        //{
        //    // مثال بسيط (يفضل تستخدم Identity أو BCrypt)
        //    return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
        //}
    }
}