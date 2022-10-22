using MovieService.Entities;
using MovieService.Repository;

namespace MovieService.Control
{
    public class MovieDataService : IMovieDataService
    {
        private readonly MovieDbContext _dbContext;

        public MovieDataService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MovieWrapper> GetAll()
        {
            return _dbContext.Movies.Select(MovieMapper.MapToWrapper).AsEnumerable();
        }

        public async Task AddAsync(MovieWrapper movieWrapper)
        {
            var movie = MovieMapper.MapToEntity(movieWrapper);
            await _dbContext.Movies.AddAsync(movie);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Remove(int id)
        {
            var movie = await _dbContext.Movies.FindAsync(id);
            if (movie == null)
            {
                return false;
            }
            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
