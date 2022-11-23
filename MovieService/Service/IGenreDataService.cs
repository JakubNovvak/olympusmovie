using MovieService.ApiModel;

namespace MovieService.Service
{
    public interface IGenreDataService
    {
        Task<int> AddAsync(GenreDTO genreDTO);
        IEnumerable<int> GetAll();
        Task<bool> RemoveRange(ISet<int> ids);
        Task<GenreDTO?> GetById(int id);
        Task<int> EditAsync(GenreDTO genreDTO);
    }
}
