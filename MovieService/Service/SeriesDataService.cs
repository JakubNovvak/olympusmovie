using MovieService.ApiModel;
using MovieService.Repository;

namespace MovieService.Service
{
    public class SeriesDataService : ISeriesDataService
    {
        private readonly MovieDbContext _dbContext;

        public SeriesDataService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(SeriesDTO seriesDTO)
        {
            var series = SeriesMapper.MapToEntity(seriesDTO);
            var createdSeries = await _dbContext.Series.AddAsync(series);
            if (createdSeries != null)
            {
                await _dbContext.SaveChangesAsync();
                return createdSeries.Entity.Id;
            }
            return 0;
        }

        public async Task<int> EditAsync(SeriesDTO seriesDTO)
        {
            var seriesEntity = SeriesMapper.MapToEntity(seriesDTO);
            var findSeries = _dbContext.Series.FirstOrDefault(series => series.Id == seriesEntity.Id);
            if (findSeries != null)
            {
                findSeries.Title = seriesEntity.Title;
                findSeries.Description = seriesEntity.Description;
                findSeries.Photo = seriesEntity.Photo;
                await _dbContext.SaveChangesAsync();
                return findSeries.Id;
            }
            return 0;
        }

        public IEnumerable<int> GetAll()
        {
            return _dbContext.Series.Select(series => series.Id);
        }

        public async Task<SeriesDTO?> GetById(int id)
        {
            var series = await _dbContext.Series.FindAsync(id);
            if (series == null)
            {
                return null;
            }
            return SeriesMapper.MapToDTO(series);
        }

        public async Task<bool> RemoveRange(ISet<int> ids)
        {
            var series = _dbContext.Series.Where(series => ids.Contains(series.Id)).ToList();
            if (series.Count == 0)
            {
                return false;
            }
            _dbContext.Series.RemoveRange(series);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
