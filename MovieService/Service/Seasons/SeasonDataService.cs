using MovieService.ApiModel.Seasons;
using MovieService.Model;
using MovieService.Repository;

namespace MovieService.Service.Seasons
{
    public class SeasonDataService : ISeasonDataService
    {
        private readonly MovieDbContext _dbContext;

        public SeasonDataService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(SeasonDTO seasonDTO)
        {
            var season = SeasonMapper.MapToEntity(seasonDTO);
            var createdSeason = await _dbContext.Set<Season>().AddAsync(season);
            
            if (createdSeason == null)
            {
                return 0;
            }

            await _dbContext.SaveChangesAsync();
            return createdSeason.Entity.Id;
        }

        public async Task<int> EditAsync(SeasonDTO seasonDTO)
        {
            var seasonEntity = SeasonMapper.MapToEntity(seasonDTO);
            var foundSeason = await _dbContext.Set<Season>().FindAsync(seasonEntity.Id);
            
            if (foundSeason == null)
            {
                return 0;
            }

            foundSeason.Title = seasonEntity.Title;
            foundSeason.Number = seasonEntity.Number;
            foundSeason.Description = seasonEntity.Description;
            foundSeason.ReleaseDate = seasonEntity.ReleaseDate;
            foundSeason.Cover = seasonEntity.Cover;
            foundSeason.BackgroundImage = seasonEntity.BackgroundImage;
            foundSeason.Thumbnail = seasonEntity.Thumbnail;
            foundSeason.Trailer = seasonEntity.Trailer;

            await _dbContext.SaveChangesAsync();
            return foundSeason.Id;
        }

        public IEnumerable<SeasonDTO> GetAll()
        {
            return _dbContext.Set<Season>().Select(SeasonMapper.MapToDTO);
        }

        public async Task<SeasonDetailsDTO?> GetById(int id)
        {
            var season = await _dbContext.Set<Season>().FindAsync(id);
            if (season == null)
            {
                return null;
            }
            return SeasonMapper.MapToDetailedDTO(season);
        }

        public async Task<bool> RemoveRange(ISet<int> ids)
        {
            var seasons = _dbContext.Set<Season>().Where(seasons => ids.Contains(seasons.Id)).ToList();
            if (seasons.Count == 0)
            {
                return false;
            }
            _dbContext.Set<Season>().RemoveRange(seasons);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
