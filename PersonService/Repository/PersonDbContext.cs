using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using PersonService.Model;

namespace PersonService.Repository
{
    public class PersonDbContext: DbContext
    {
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;

        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
        {
            var databaseCreator = Database.GetService<IDatabaseCreator>();
            if (databaseCreator != null)
            {
                databaseCreator.EnsureCreated();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonMovie>()
                .HasOne(pm => pm.Person)
                .WithMany(p => p.MoviesId)
                .HasForeignKey(pm => pm.MovieId)
                .OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<PersonMovie>()
            //    .HasOne(pm => pm.Series)
            //    .WithMany(p => p.SeriesId)
            //    .HasForeignKey(pm => pm.SeriesId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            base.OnConfiguring(optionBuilder);
            optionBuilder.UseLazyLoadingProxies();
        }
    }
}
