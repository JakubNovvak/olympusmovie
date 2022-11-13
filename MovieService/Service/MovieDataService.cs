using MovieService.Repository;

namespace MovieService.Service
{
    public class MovieDataService : IMovieDataService
    {
        private readonly MovieDbContext _dbContext;

        public MovieDataService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<int> GetAll()
        {
            return _dbContext.Movies.Select(movie => movie.Id);
        }

        public async Task<MovieWrapper?> GetById(int id)
        {
            var movie = await _dbContext.Movies.FindAsync(id);
            if (movie == null)
            {
                return null;
            }
            return MovieMapper.MapToWrapper(movie);
        }

        public async Task<int> AddAsync(MovieWrapper movieWrapper)
        {
            var movie = MovieMapper.MapToEntity(movieWrapper);
            var createdMovie = await _dbContext.Movies.AddAsync(movie);
            if (createdMovie != null)
            {
                await _dbContext.SaveChangesAsync();
                return createdMovie.Entity.Id;
            }
            return 0;
        }

        public async Task<bool> RemoveRange(ISet<int> ids)
        {
            var movies = _dbContext.Movies.Where(movie => ids.Contains(movie.Id)).ToList();
            if (movies.Count == 0)
            {
                return false;
            }
            _dbContext.Movies.RemoveRange(movies);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
