using MovieService.ApiModel;

namespace MovieService.Service
{
    public interface ISeasonDataService
    {
        Task<int> AddAsync(SeasonsDTO seasonDTO);
        IEnumerable<int> GetAllFromOneSeries(int seriesId);
        Task<bool> RemoveRange(ISet<int> ids);
        Task<SeasonsDTO?> GetById(int id);
        Task<int> EditAsync(SeasonsDTO seasonDTO);
    }
}
