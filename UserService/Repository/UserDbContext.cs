using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using UserService.Model;
using UserService.Model.Relations;

namespace UserService.Repository
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserToMovieRelation> UserToMovieRelations { get; set; } = null!;
        public DbSet<UserToSeriesRelation> UserToSeriesRelations { get; set; } = null!;

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserToMovieRelation>().HasKey(entity => new
            {
                entity.UserId,
                entity.RelatedMovieId,
                entity.TypeOfRelation
            });
            modelBuilder.Entity<UserToSeriesRelation>().HasKey(entity => new
            {
                entity.UserId,
                entity.RelatedSeriesId,
                entity.TypeOfRelation
            });
        }
    }
}
