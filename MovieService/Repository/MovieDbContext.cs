using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using MovieService.Entities;

namespace MovieService.Repository
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        {
            var databaseCreator = Database.GetService<IDatabaseCreator>();
            if (databaseCreator != null)
            {
                databaseCreator.EnsureCreated();
            }
        }

        public DbSet<Movie> Movies { get; set; } = null!;
    }
}
