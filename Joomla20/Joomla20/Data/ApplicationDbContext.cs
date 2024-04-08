using Joomla20.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Joomla20.Data
{
    public class ApplicationDbContext : IdentityDbContext<JUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { 
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<JUser> JUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<JUser>().ToTable("Users");
            modelBuilder.Entity<JUser>().Property(u => u.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Article>().Property(a => a.CreatedAt).HasDefaultValue(DateTime.UtcNow);

            var hasher = new PasswordHasher<JUser>();
            var adminId = Guid.NewGuid();
            var AdminRoleId = Guid.NewGuid();


            modelBuilder.Entity<IdentityRole<Guid>>().HasData(new IdentityRole<Guid>
            {
                Id = AdminRoleId,
                Name = "Administrator",
                NormalizedName = "ADMIN",
            });
            modelBuilder.Entity<JUser>().HasData(new JUser
            {
                Id = adminId,
                UserName = "admin@Dev.null",
                NormalizedUserName = "ADMIN@DEV.NULL",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(new JUser(), "Admin"),
            });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = adminId,
                UserId = AdminRoleId,
            });
        }
    }
}
