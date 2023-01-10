using MovieService.ApiModel.Episodes;
using MovieService.Model;
using MovieService.Repository;

namespace MovieService.Service.Episodes
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
            var episode = EpisodeMapper.MapToEntity(episodeDTO);
            var createEpisode = await _dbContext.Set<Episode>().AddAsync(episode);
            if (createEpisode != null)
            {
                await _dbContext.SaveChangesAsync();
                return createEpisode.Entity.Id;
            }
            return 0;
        }
        
        public async Task<int> EditAsync(EpisodeDTO episodeDTO)
        {
            var episodeEntity = EpisodeMapper.MapToEntity(episodeDTO);
            var foundEpisode = await _dbContext.Set<Episode>().FindAsync(episodeEntity.Id);
            
            if (foundEpisode == null)
            {
                return 0;
            }

            foundEpisode.SeasonId = episodeEntity.SeasonId;
            foundEpisode.EpisodeNumber = episodeEntity.EpisodeNumber;
            foundEpisode.Title = episodeEntity.Title;
            foundEpisode.ReleaseDate = episodeEntity.ReleaseDate;
            foundEpisode.DurationInMinutes = episodeEntity.DurationInMinutes;
            foundEpisode.Description = episodeEntity.Description;
            await _dbContext.SaveChangesAsync();
            
            return foundEpisode.Id;
        }

        public IEnumerable<EpisodeDTO> GetAll()
        {
            return _dbContext.Set<Episode>().Select(episode => EpisodeMapper.MapToDTO(episode));
        }

        public async Task<EpisodeDTO?> GetById(int id)
        {
            var episode = await _dbContext.Set<Episode>().FindAsync(id);
            if (episode == null)
            {
                return null;
            }
            return EpisodeMapper.MapToDTO(episode);
        }

        public async Task<bool> RemoveRange(ISet<int> ids)
        {
            var episodes = _dbContext.Set<Episode>().Where(episode => ids.Contains(episode.Id)).ToList();
            if (episodes.Count == 0)
            {
                return false;
            }
            _dbContext.Set<Episode>().RemoveRange(episodes);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
