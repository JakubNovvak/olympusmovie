using MovieService.ApiModel;
using MovieService.Model;
using MovieService.Repository;

namespace MovieService.Service
{
    public class SeasonDataService : ISeasonDataService
    {
        private readonly MovieDbContext _dbContext;

        public SeasonDataService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(SeasonsDTO seasonDTO)
        {
            var season = SeasonMapper.MapToEntity(seasonDTO);
            var createdSeason = await _dbContext.Seasons.AddAsync(season);
            if (createdSeason != null)
            {
                await _dbContext.SaveChangesAsync();
                return createdSeason.Entity.Id;
            }
            return 0;
        }

        public async Task<int> EditAsync(SeasonsDTO seasonDTO)
        {
            var seasonEntity = SeasonMapper.MapToEntity(seasonDTO);
            var findSeason = _dbContext.Seasons.FirstOrDefault(series => series.Id == seasonEntity.Id);
            if (findSeason != null)
            {
                findSeason.Title = seasonEntity.Title;
                findSeason.Number = seasonEntity.Number;
                findSeason.Title = seasonEntity.Title;
                await _dbContext.SaveChangesAsync();
                return findSeason.Id;
            }
            return 0;
        }

        public IEnumerable<int> GetAllFromOneSeries(int seriesId)
        {
            return _dbContext.Seasons.Where(seasons => seasons.Id == seriesId).Select(season => season.Id);
        }

        public async Task<SeasonsDTO?> GetById(int id)
        {
            var season = await _dbContext.Seasons.FindAsync(id);
            if (season == null)
            {
                return null;
            }
            return SeasonMapper.MapToDTO(season);
        }

        public async Task<bool> RemoveRange(ISet<int> ids)
        {
            var seasons = _dbContext.Seasons.Where(seasons => ids.Contains(seasons.Id)).ToList();
            if (seasons.Count == 0)
            {
                return false;
            }
            _dbContext.Seasons.RemoveRange(seasons);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
