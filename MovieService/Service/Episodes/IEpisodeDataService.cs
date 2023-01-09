using MovieService.ApiModel.Episodes;

namespace MovieService.Service.Episodes
{
    public interface IEpisodeDataService
    {
        Task<int> AddAsync(EpisodeDTO episodeDTO);
        IEnumerable<int> GetAll();
        Task<bool> RemoveRange(ISet<int> ids);
        Task<EpisodeDTO?> GetById(int id);
        Task<int> EditAsync(EpisodeDTO episodeDTO);
    }
}
