
namespace MovieService.Service
{
    public interface IMovieDataService
    {
        Task<int> AddAsync(MovieWrapper movieWrapper);
        IEnumerable<int> GetAll();
        Task<bool> RemoveRange(ISet<int> id);
        Task<MovieWrapper?> GetById(int id);
    }
}