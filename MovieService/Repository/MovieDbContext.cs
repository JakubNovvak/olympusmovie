﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using MovieService.Model;

namespace MovieService.Repository
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Episode> Episodes { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Rating> Ratings { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Season> Seasons { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;

        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
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
            modelBuilder.Entity<Participant>().HasKey(entity => new
            {
                entity.PersonId,
                entity.MovieId,
                entity.SeasonId,
                entity.RoleId
            });
        }
    }
}
