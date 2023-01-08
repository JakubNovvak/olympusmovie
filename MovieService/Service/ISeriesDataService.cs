using MovieService.ApiModel;

namespace MovieService.Service
{
    public interface ISeriesDataService
    {
        Task<int> AddAsync(SeriesDTO seriesDTO);
        IEnumerable<int> GetAll();
        Task<bool> RemoveRange(ISet<int> ids);
        Task<SeriesDetailsDTO?> GetById(int id);
        Task<int> EditAsync(SeriesDTO seriesDTO);
    }
}
