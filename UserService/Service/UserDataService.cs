using Microsoft.AspNetCore.Components.Forms;
using UserService.ApiModel;
using UserService.Model.Relations;
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

        public async Task AddMoviesPlannedToWatch(int userId, int movieId)
        {
            var createdRelation = await _dbContext.PlanToWatchRelations.AddAsync(new PlanToWatchRelation(userId, movieId));
            if (createdRelation != null)
            {
                await _dbContext.SaveChangesAsync();
            }
        }

        public bool UserExists(int userId)
        {
            return _dbContext.Users.Where(user => user.Id == userId).Any();
        }

        public IList<int> GetMoviesToPlanToWatch(int userId)
        {
            return _dbContext.PlanToWatchRelations
                .Where(relation => relation.RelatedUserId == userId)
                .Select(relation => relation.RelatedMovieId)
                .ToList();
        }
    }
}
