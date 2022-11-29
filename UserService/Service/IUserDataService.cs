using UserService.ApiModel;

namespace UserService.Service
{
    public interface IUserDataService
    {
        Task<int> AddAsync(UserDTO userDTO);
        Task<bool> Remove(int id);
        Task<UserDTO?> GetById(int id);
    }
}
