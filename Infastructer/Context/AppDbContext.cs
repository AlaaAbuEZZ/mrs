using Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Infastructer.Context
{
    public class AppDbContext : DbContext

    { public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestDetail> RequestDetails { get; set; }
        public DbSet<RequestHitory> RequestHitories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TechnicianCategory> TechnicianCategories { get; set; }
        public DbSet<Token> Tokens { get; set; }

    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<RequestHitory>()
            //    .HasOne(x => x.User)
            //    .WithMany()
            //    .HasForeignKey(x => x.UserId)
            //    .OnDelete(DeleteBehavior.NoAction);

            //modelBuilder.Entity<RequestHitory>()
            //    .HasOne(x => x.Request)
            //    .WithMany()
            //    .HasForeignKey(x => x.RequestId)
            //    .OnDelete(DeleteBehavior.NoAction);
            var relationships = modelBuilder.Model
                .GetEntityTypes().SelectMany(e => e.GetForeignKeys());
            foreach (var relationship in relationships)
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            }
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    } }
