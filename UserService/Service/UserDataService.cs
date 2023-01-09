using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using UserService.ApiModel;
using UserService.Infrastructure;
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

        public async Task<int> ChangeAccountData(UserDTO userDTO)
        {
            var userEntity = UserMapper.MapToEntity(userDTO);
            var userToEdit = _dbContext.Users.FirstOrDefault(user => user.Id == userDTO.Id);
            if (userToEdit != null)
            {
                userToEdit.Name = userDTO.Name;
                userToEdit.Surname = userDTO.Surname;
                userToEdit.Email = userDTO.Email;
                userToEdit.Photo = userDTO.Photo;
                userToEdit.BackgroundPhoto = userDTO.BackgroundPhoto;
                await _dbContext.SaveChangesAsync();
                return userToEdit.Id;
            }
            return 0;
        }

        public List<int> GetUserRelatedObjectIds(int userId, string typeOfRelation, string typeOfPosition) => _dbContext.Set<UserRelationToPosition>()
            .Where(relation => relation.RelatedPositionType == typeOfPosition)
            .Where(relation => relation.TypeOfRelation == typeOfRelation)
            .Where(relation => relation.UserId == userId)
            .Select(relation => relation.RelatedPositionId)
            .ToList();

        public async Task<List<int>> SyncUserToObjectRelations(int userId, ISet<int> objectIds, string typeOfRelation, string typeOfPosition)
        {
            if (typeOfRelation != RelationTypeConstants.FAVORITE) {
                var relationTypesExceptFavorite = RelationTypeConstants.GetAllRelationTypes()
                    .Where(type => type != RelationTypeConstants.FAVORITE)
                    .ToList();
                await RemoveUserToObjectRelations(userId, objectIds, relationTypesExceptFavorite, typeOfPosition);
            }
            else
            {
                await RemoveUserToObjectRelations(userId, objectIds, new List<string> { RelationTypeConstants.FAVORITE }, typeOfPosition);
            }
            var entities = objectIds.Select(objectId => new UserRelationToPosition
            {
                UserId = userId,
                TypeOfRelation = typeOfRelation,
                RelatedPositionId = objectId,
                RelatedPositionType = typeOfPosition
            }).ToList();
            
            await _dbContext.Set<UserRelationToPosition>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();

            return _dbContext.Set<UserRelationToPosition>()
                .Where(relation => relation.TypeOfRelation == typeOfRelation)
                .Where(relation => relation.RelatedPositionType == typeOfPosition)
                .Select(relation => relation.RelatedPositionId).ToList();
        }
        
        public async Task RemoveUserToObjectRelations(int userId, ISet<int> positionIds, List<string> relationTypes, string typeOfPosition)
        {
            var relations = _dbContext.Set<UserRelationToPosition>()
                .Where(relation => relation.RelatedPositionType == typeOfPosition)
                .Where(relation => relation.UserId == userId)
                .Where(relation => relationTypes.Contains(relation.TypeOfRelation))
                .Where(relation => positionIds.Contains(relation.RelatedPositionId))
                .ToList();
            _dbContext.Set<UserRelationToPosition>().RemoveRange(relations);
            await _dbContext.SaveChangesAsync();
        }

        public bool UserExists(int userId)
        {
            return _dbContext.Users.Where(user => user.Id == userId).Any();
        }

        public async Task SyncEpisodeCount(int userId, int[] seasonIds, int episodeCount)
        {
            var relationsToUpdate = _dbContext.UsersWatchedEpisodesCounts
                .Where(relation => relation.UserId == userId)
                .Where(relation => seasonIds.Contains(relation.SeasonId));
            _dbContext.UsersWatchedEpisodesCounts
                .RemoveRange(relationsToUpdate);
            
            var updatedRelations = seasonIds.Select(seasonId => new UserWatchedEpisodesCount()
            {
                UserId = userId,
                SeasonId = seasonId,
                WatchedCount = episodeCount
            });
            
            await _dbContext.UsersWatchedEpisodesCounts
                .AddRangeAsync(relationsToUpdate);
        }

        public List<int> GetEpisodeCount(int userId, int seasonId) => _dbContext.UsersWatchedEpisodesCounts
            .Where(relation => relation.UserId == userId)
            .Where(relation => relation.SeasonId == seasonId)
            .Select(relation => relation.WatchedCount)
            .ToList();
    }
}
