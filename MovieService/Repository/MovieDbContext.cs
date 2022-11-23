﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using MovieService.Model;

namespace MovieService.Repository
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Episode> Episodes { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Role> Roles { get; set; } = null!;
        public DbSet<Series> Series { get; set; } = null!;
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
    }
}
