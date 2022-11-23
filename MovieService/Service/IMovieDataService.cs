
using MovieService.ApiModel;

namespace MovieService.Service
{
    public interface IMovieDataService
    {
        Task<int> AddAsync(MovieDTO movieDTO);
        IEnumerable<int> GetAll();
        Task<bool> RemoveRange(ISet<int> ids);
        Task<MovieDTO?> GetById(int id);
        Task<int> EditAsync(MovieDTO movieDTO);
    }
}