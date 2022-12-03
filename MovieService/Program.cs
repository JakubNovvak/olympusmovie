using Microsoft.EntityFrameworkCore;
using MovieService.Service;
using MovieService.Repository;
using JwtAuthenticationManager;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(p => p.AddPolicy("corspolicy", build =>
{
    build.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddCustomJwtAuthentication();

// Database configuration
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};User ID=sa;Password={dbPassword};TrustServerCertificate=True";
builder.Services.AddDbContext<MovieDbContext>(options => options.UseSqlServer(connectionString));

// Register services
builder.Services.AddScoped<IEpisodeDataService, EpisodeDataService>();
builder.Services.AddScoped<IGenreDataService, GenreDataService>();
builder.Services.AddScoped<IMovieDataService, MovieDataService>();
builder.Services.AddScoped<IPersonDataService, PersonDataService>();
builder.Services.AddScoped<IRoleDataService, RoleDataService>();
builder.Services.AddScoped<ISeriesDataService, SeriesDataService>();
builder.Services.AddScoped<ITagDataService, TagDataService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("corspolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
