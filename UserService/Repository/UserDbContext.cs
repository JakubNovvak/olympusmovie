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
        public DbSet<UserRelationToPosition> UsersToPositionsRelations { get; set; } = null!;
        public DbSet<UserWatchedEpisodesCount> UsersWatchedEpisodesCounts { get; set; } = null!;

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
            modelBuilder.Entity<UserRelationToPosition>().HasKey(relation => new
            {
                relation.UserId,
                relation.TypeOfRelation,
                relation.RelatedPositionId,
                relation.RelatedPositionType
            });
            modelBuilder.Entity<UserWatchedEpisodesCount>().HasKey(relation => new
            {
                relation.UserId,
                relation.SeasonId
            });
        }
    }
}
