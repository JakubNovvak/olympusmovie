
namespace MovieService.Control
{
    public interface IMovieDataService
    {
        Task AddAsync(MovieWrapper movieWrapper);
        IEnumerable<MovieWrapper> GetAll();
        Task<bool> Remove(int id);
    }
}