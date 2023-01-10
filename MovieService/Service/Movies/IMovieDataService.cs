using MovieService.ApiModel.Movies;

namespace MovieService.Service.Movies
{
    public interface IMovieDataService
    {
        Task<int> AddAsync(MovieCreateEditDTO movieDTO);
        IEnumerable<MovieDTO> GetAll();
        Task<bool> RemoveRange(ISet<int> ids);
        Task<MovieDetailsDTO?> GetById(int id);
        Task<int> EditAsync(MovieCreateEditDTO movieDTO);
    }
}