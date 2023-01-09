using MovieService.ApiModel.Genres;

namespace MovieService.Service.Genres
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
