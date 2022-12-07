using Microsoft.EntityFrameworkCore;
using AuthenticationService.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace AuthenticationService.Repository
{
    public class UserAccountDbContext : IdentityDbContext<ApplicationUser>
    {
        public UserAccountDbContext(DbContextOptions<UserAccountDbContext> options) : base(options)
        {
            var databaseCreator = Database.GetService<IDatabaseCreator>();
            if (databaseCreator != null)
            {
                databaseCreator.EnsureCreated();
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
