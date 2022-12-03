using UserService.ApiModel;
using UserService.Repository;

namespace UserService.Service
{
    public class UserDataService : IUserDataService
    {
        private readonly UserDbContext _dbContext;

        public UserDataService(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(UserDTO userDTO)
        {
            var user = UserMapper.MapToEntity(userDTO);
            var createdUser = await _dbContext.Users.AddAsync(user);
            if (createdUser != null)
            {
                await _dbContext.SaveChangesAsync();
                return createdUser.Entity.Id;
            }
            return 0;
        }

        public async Task<UserDTO?> GetById(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            return UserMapper.MapToDTO(user);
        }

        public async Task<bool> Remove(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
