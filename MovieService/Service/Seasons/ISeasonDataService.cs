using MovieService.ApiModel.Seasons;

namespace MovieService.Service.Seasons
{
    public interface ISeasonDataService
    {
        Task<int> AddAsync(SeasonCreateEditDTO seasonDTO);
        IEnumerable<SeasonDTO> GetAll();
        Task<bool> RemoveRange(ISet<int> ids);
        Task<SeasonDetailsDTO?> GetById(int id);
        Task<int> EditAsync(SeasonCreateEditDTO seasonDTO);
    }
}
