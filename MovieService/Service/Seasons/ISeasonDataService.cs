using MovieService.ApiModel.Seasons;

namespace MovieService.Service.Seasons
{
    public interface ISeasonDataService
    {
        Task<int> AddAsync(SeasonDTO seasonDTO);
        IEnumerable<SeasonDTO> GetAll();
        Task<bool> RemoveRange(ISet<int> ids);
        Task<SeasonDetailsDTO?> GetById(int id);
        Task<int> EditAsync(SeasonDTO seasonDTO);
    }
}
