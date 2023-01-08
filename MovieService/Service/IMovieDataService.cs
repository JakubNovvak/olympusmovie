
using MovieService.ApiModel;

namespace MovieService.Service
{
    public interface IMovieDataService
    {
        Task<int> AddAsync(MovieDTO movieDTO);
        IEnumerable<MovieDTO> GetAll();
        Task<bool> RemoveRange(ISet<int> ids);
        Task<MovieDetailsDTO?> GetById(int id);
        Task<int> EditAsync(MovieDTO movieDTO);
    }
}