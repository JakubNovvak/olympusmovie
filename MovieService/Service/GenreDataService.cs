using MovieService.ApiModel;
using MovieService.Repository;

namespace MovieService.Service
{
    public class GenreDataService : IGenreDataService
    {
        private readonly MovieDbContext _dbContext;

        public GenreDataService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(GenreDTO genreDTO)
        {
            var genre = GenreMapper.MapToEntity(genreDTO);
            var createdGenre = await _dbContext.Genres.AddAsync(genre);
            if (createdGenre != null)
            {
                await _dbContext.SaveChangesAsync();
                return createdGenre.Entity.Id;
            }
            return 0;
        }

        public async Task<int> EditAsync(GenreDTO genreDTO)
        {
            var genreEntity = GenreMapper.MapToEntity(genreDTO);
            var findGenre = _dbContext.Genres.FirstOrDefault(movie => movie.Id == genreEntity.Id);
            if (findGenre != null)
            {
                findGenre.Name = genreEntity.Name;
                findGenre.Description = genreEntity.Description;
                await _dbContext.SaveChangesAsync();
                return findGenre.Id;
            }
            return 0;
        }

        public IEnumerable<int> GetAll()
        {
            return _dbContext.Genres.Select(genre => genre.Id);
        }

        public async Task<GenreDTO?> GetById(int id)
        {
            var genre = await _dbContext.Genres.FindAsync(id);
            if (genre == null)
            {
                return null;
            }
            return GenreMapper.MapToDTO(genre);
        }

        public async Task<bool> RemoveRange(ISet<int> ids)
        {
            var genres = _dbContext.Genres.Where(genre => ids.Contains(genre.Id)).ToList();
            if (genres.Count == 0)
            {
                return false;
            }
            _dbContext.Genres.RemoveRange(genres);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
