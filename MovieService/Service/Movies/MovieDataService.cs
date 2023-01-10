using MovieService.ApiModel.Movies;
using MovieService.Model;
using MovieService.Repository;
using MovieService.Service.Participants;

namespace MovieService.Service.Movies
{
    public class MovieDataService : IMovieDataService
    {
        private readonly MovieDbContext _dbContext;

        public MovieDataService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(MovieCreateEditDTO movieDTO)
        {
            var movie = new Movie
            {
                Title = movieDTO.Title,
                Description = movieDTO.Description,
                ReleaseDate = new DateTime(movieDTO.ReleaseDate.Year, movieDTO.ReleaseDate.Month, movieDTO.ReleaseDate.Day),
                DurationInMinutes = movieDTO.DurationInMinutes,
                Cover = movieDTO.Cover,
                BackgroundImage = movieDTO.BackgroundImage,
                Thumbnail = movieDTO.Thumbnail,
                Trailer = movieDTO.Trailer,
                Tags = _dbContext.Set<Tag>().Where(tag => movieDTO.TagIds.Contains(tag.Id)).ToList(),
                Genres = _dbContext.Set<Genre>().Where(genre => movieDTO.GenreIds.Contains(genre.Id)).ToList(),
                Reviews = _dbContext.Set<Review>().Where(review => movieDTO.GenreIds.Contains(review.Id)).ToList()
            };
            
            await _dbContext.SaveChangesAsync();
            var createdMovie = await _dbContext.Set<Movie>().AddAsync(movie);
            
            if (createdMovie != null)
            {
                await _dbContext.SaveChangesAsync();
                SyncMovieParticipantsWithoutSave(movieDTO, createdMovie.Entity.Id);
                await _dbContext.SaveChangesAsync();
                return createdMovie.Entity.Id;
            }
            return 0;
        }

        public async Task<int> EditAsync(MovieCreateEditDTO movieDTO)
        {
            var movieToEdit = await _dbContext.Set<Movie>().FindAsync(movieDTO.Id);

            if (movieToEdit == null)
            {
                return 0;
            }

            movieToEdit.Title = movieDTO.Title;
            movieToEdit.Description = movieDTO.Description;
            movieToEdit.ReleaseDate = new DateTime(movieDTO.ReleaseDate.Year, movieDTO.ReleaseDate.Month, movieDTO.ReleaseDate.Day);
            movieToEdit.DurationInMinutes = movieDTO.DurationInMinutes;
            movieToEdit.Cover = movieDTO.Cover;
            movieToEdit.BackgroundImage = movieDTO.BackgroundImage;
            movieToEdit.Thumbnail = movieDTO.Thumbnail;
            movieToEdit.Trailer = movieDTO.Trailer;
            movieToEdit.Tags = _dbContext.Set<Tag>().Where(tag => movieDTO.TagIds.Contains(tag.Id)).ToList();
            movieToEdit.Genres = _dbContext.Set<Genre>().Where(genre => movieDTO.GenreIds.Contains(genre.Id)).ToList();
            movieToEdit.Reviews = _dbContext.Set<Review>().Where(review => movieDTO.GenreIds.Contains(review.Id)).ToList();
            SyncMovieParticipantsWithoutSave(movieDTO, movieToEdit.Id);
            await _dbContext.SaveChangesAsync();
            
            return movieToEdit.Id;
        }

        private void SyncMovieParticipantsWithoutSave(MovieCreateEditDTO movieDTO, int movieId)
        {
            var currentMovieParticipants = _dbContext.Set<ParticipantMovie>()
                .Where(participantMovie => participantMovie.MovieId == movieId).ToList();
            _dbContext.ParticipantsOfMovies.RemoveRange(currentMovieParticipants);
            _dbContext.ParticipantsOfMovies.AddRange(movieDTO.Participants.Select(participant => ParticipantMapper.MapToEntity(participant, movieId)));
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
