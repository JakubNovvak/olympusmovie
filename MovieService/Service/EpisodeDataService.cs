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
            throw new NotImplementedException();
        }

        public async Task<int> EditAsync(EpisodeDTO episodeDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<EpisodeDTO?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveRange(ISet<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
