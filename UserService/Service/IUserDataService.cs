using UserService.ApiModel;

namespace UserService.Service
{
    public interface IUserDataService
    {
        Task<int> AddAsync(UserDTO userDTO);
        Task<bool> Remove(int id);
        Task<UserDTO?> GetById(int id);
        Task AddMoviesPlannedToWatch(int userId, int movieId);
        bool UserExists(int userId);
        IList<int> GetMoviesToPlanToWatch(int userId);
    }
}
