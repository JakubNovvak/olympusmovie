using UserService.ApiModel;

namespace UserService.Service
{
    public interface IUserDataService
    {
        Task<int> AddAsync(UserDTO userDTO);
        Task<bool> Remove(int id);
        Task<UserDTO?> GetById(int id);
        bool UserExists(int userId);
        Task AddUserToMovieRelations(int userId, List<int> movieIds, string relationType);
        List<int> GetUserMovies(int userId, string typeOfRelation);
        Task AddUserToSeriesRelations(int userId, List<int> seriesIds, string relationType);
        List<int> GetUserSeries(int userId, string typeOfRelation);
        Task RemoveUserToMovieRelations(ISet<int> userIds, ISet<int> movieIds, string? relationType);
        Task RemoveUserToSeriesRelations(ISet<int> userIds, ISet<int> seriesIds, string? relationType);
    }
}
