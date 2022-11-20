using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using PersonService.Model;

namespace PersonService.Repository
{
    public class PersonDbContext: DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
            var databaseCreator = Database.GetService<IDatabaseCreator>();
            if (databaseCreator != null)
            {
                databaseCreator.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            base.OnConfiguring(optionBuilder);
            optionBuilder.UseLazyLoadingProxies();
        }

        //public DbSet<Person> Persons{ get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
    }
}
