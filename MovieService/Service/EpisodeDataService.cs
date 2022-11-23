using MovieService.ApiModel;
using MovieService.Repository;

namespace MovieService.Service
{
    public class EpisodeDataService : IEpisodeDataService
    {
        private readonly MovieDbContext _dbContext;

        public EpisodeDataService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddAsync(EpisodeDTO episodeDTO)
        {
            var episode = EpisodeMapper.MapToEntity(episodeDTO, true);
            var createEpisode = await _dbContext.Episodes.AddAsync(episode);
            if (createEpisode != null)
            {
                await _dbContext.SaveChangesAsync();
                return createEpisode.Entity.Id;
            }
            return 0;
        }

        public async Task<int> EditAsync(EpisodeDTO episodeDTO)
        {
            var episodeEntity = EpisodeMapper.MapToEntity(episodeDTO, false);
            var findEpisode = _dbContext.Episodes.FirstOrDefault(episode => episode.Id == episodeEntity.Id);
            if (findEpisode != null)
            {
                findEpisode.Season = episodeEntity.Season;
                findEpisode.EpisodeNumber = episodeEntity.EpisodeNumber;
                findEpisode.Title = episodeEntity.Title;
                findEpisode.ReleaseDate = episodeEntity.ReleaseDate;
                findEpisode.DurationInMinutes = episodeEntity.DurationInMinutes;
                findEpisode.Description = episodeEntity.Description;
                await _dbContext.SaveChangesAsync();
                return findEpisode.Id;
            }
            return 0;
        }

        public IEnumerable<int> GetAll()
        {
            return _dbContext.Episodes.Select(episode => episode.Id);
        }

        public async Task<EpisodeDTO?> GetById(int id)
        {
            var episode = await _dbContext.Episodes.FindAsync(id);
            if (episode == null)
            {
                return null;
            }
            return EpisodeMapper.MapToDTO(episode);
        }

        public async Task<bool> RemoveRange(ISet<int> ids)
        {
            var episodes = _dbContext.Episodes.Where(episode => ids.Contains(episode.Id)).ToList();
            if (episodes.Count == 0)
            {
                return false;
            }
            _dbContext.Episodes.RemoveRange(episodes);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
