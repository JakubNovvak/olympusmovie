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

        public async Task AddUserToMovieRelations(int userId, List<int> movieIds, string relationType)
        {
            var entities = movieIds.Select(movieId => new UserToMovieRelation
            {
                UserId = userId,
                RelatedMovieId = movieId,
                TypeOfRelation = relationType
            }).ToList();
            await _dbContext.UserToMovieRelations.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task RemoveUserToMovieRelations(ISet<int> userIds, ISet<int> movieIds, string? relationType)
        {
            var relations = _dbContext.UserToMovieRelations
                .Where(relation => relationType == null || relationType == relation.TypeOfRelation)
                .Where(relation => userIds.Contains(relation.UserId))
                .Where(relation => movieIds.Contains(relation.RelatedMovieId))
                .ToList();
            if (relations.Count == 0)
            {
                return;
            }
            _dbContext.UserToMovieRelations.RemoveRange(relations);
            await _dbContext.SaveChangesAsync();
        }
        
        public List<int> GetUserMovies(int userId, string typeOfRelation)
        {
            return _dbContext.UserToMovieRelations
                            .Where(relation => relation.UserId == userId && relation.TypeOfRelation == typeOfRelation)
                            .Select(relation => relation.RelatedMovieId)
                            .ToList();
        }

        public async Task AddUserToSeriesRelations(int userId, List<int> seriesIds, string relationType)
        {
            var entities = seriesIds.Select(movieId => new UserToSeriesRelation
            {
                UserId = userId,
                RelatedSeriesId = movieId,
                TypeOfRelation = relationType
            }).ToList();
            await _dbContext.UserToSeriesRelations.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveUserToSeriesRelations(ISet<int> userIds, ISet<int> seriesIds, string? relationType)
        {
            var relations = _dbContext.UserToSeriesRelations
                .Where(relation => relationType == null || relationType == relation.TypeOfRelation)
                .Where(relation => userIds.Contains(relation.UserId))
                .Where(relation => seriesIds.Contains(relation.RelatedSeriesId))
                .ToList();
            if (relations.Count == 0)
            {
                return;
            }
            _dbContext.UserToSeriesRelations.RemoveRange(relations);
            await _dbContext.SaveChangesAsync();
        }

        public List<int> GetUserSeries(int userId, string typeOfRelation)
        {
            return _dbContext.UserToSeriesRelations
                            .Where(relation => relation.UserId == userId && relation.TypeOfRelation == typeOfRelation)
                            .Select(relation => relation.RelatedSeriesId)
                            .ToList();
        }

        public bool UserExists(int userId)
        {
            return _dbContext.Users.Where(user => user.Id == userId).Any();
        }
    }
}
