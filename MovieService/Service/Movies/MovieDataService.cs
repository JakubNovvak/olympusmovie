using MovieService.ApiModel.Movies;
using MovieService.Model;
using MovieService.Repository;

namespace MovieService.Service.Movies
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
            var movie = MovieMapper.MapToEntity(movieDTO);
            var createdMovie = await _dbContext.Set<Movie>().AddAsync(movie);
            if (createdMovie != null)
            {
                await _dbContext.SaveChangesAsync();
                return createdMovie.Entity.Id;
            }
            return 0;
        }

        public async Task<int> EditAsync(MovieDTO movieDTO)
        {
            var movieEntity = MovieMapper.MapToEntity(movieDTO);
            var movieToEdit = await _dbContext.Set<Movie>().FindAsync(movieEntity.Id);

            if (movieToEdit == null)
            {
                return 0;
            }

            movieToEdit.Title = movieEntity.Title;
            movieToEdit.Description = movieEntity.Description;
            movieToEdit.ReleaseDate = movieEntity.ReleaseDate;
            movieToEdit.DurationInMinutes = movieEntity.DurationInMinutes;
            movieToEdit.Cover = movieEntity.Cover;
            movieToEdit.BackgroundImage = movieEntity.BackgroundImage;
            movieToEdit.Thumbnail = movieEntity.Thumbnail;
            movieToEdit.Trailer = movieEntity.Trailer;
            await _dbContext.SaveChangesAsync();
            return movieToEdit.Id;
        }

        public IEnumerable<MovieDTO> GetAll()
        {
            return _dbContext.Movies.Select(movie => MovieMapper.MapToDTO(movie));
        }

        public async Task<MovieDetailsDTO?> GetById(int id)
        {
            var movie = await _dbContext.Set<Movie>().FindAsync(id);
            if (movie == null)
            {
                return null;
            }
            return MovieMapper.MapToDetailsDTO(movie);
        }

        public async Task<bool> RemoveRange(ISet<int> ids)
        {
            var movies = _dbContext.Set<Movie>().Where(movie => ids.Contains(movie.Id)).ToList();
            if (movies.Count == 0)
            {
                return false;
            }
            _dbContext.Set<Movie>().RemoveRange(movies);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
