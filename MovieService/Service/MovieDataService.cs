using MovieService.ApiModel;
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

        public async Task<int> AddAsync(MovieDTO movieDTO)
        {
            var movie = MovieMapper.MapToEntity(movieDTO, true);
            var createdMovie = await _dbContext.Movies.AddAsync(movie);
            if (createdMovie != null)
            {
                await _dbContext.SaveChangesAsync();
                return createdMovie.Entity.Id;
            }
            return 0;
        }

        public async Task<int> EditAsync(MovieDTO movieDTO)
        {
            var movieEntity = MovieMapper.MapToEntity(movieDTO, false);
            var findMovie = _dbContext.Movies.FirstOrDefault(movie => movie.Id == movieEntity.Id);
            if(findMovie != null)
            {
                findMovie.Title = movieEntity.Title;
                findMovie.Description = movieEntity.Description;
                findMovie.DateOfRelease = movieEntity.DateOfRelease;
                findMovie.DurationInMinutes = movieEntity.DurationInMinutes;
                findMovie.Photo = movieEntity.Photo;
                await _dbContext.SaveChangesAsync();
                return findMovie.Id;
            }
            return 0;
        }

        public IEnumerable<MovieDTO> GetAll()
        {
            return _dbContext.Movies.Select(movie => MovieMapper.MapToDTO(movie));
        }

        public async Task<MovieDTO?> GetById(int id)
        {
            var movie = await _dbContext.Movies.FindAsync(id);
            if (movie == null)
            {
                return null;
            }
            return MovieMapper.MapToDTO(movie);
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
