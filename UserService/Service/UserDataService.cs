using Microsoft.AspNetCore.Components.Forms;
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

        public List<int> GetUserRelatedObjectIds<TRelation>(int userId, string typeOfRelation)
            where TRelation : Relation
        {
            return _dbContext.Set<TRelation>()
                .Where(relation => relation.TypeOfRelation == typeOfRelation)
                .Where(relation => relation.UserId == userId)
                .Select(relation => relation.RelatedObjectId)
                .ToList();
        }

        public async Task SyncUserToObjectRelations<TRelation>(int userId, ISet<int> objectIds, string typeOfRelation)
            where TRelation : Relation, new()
        {
            if (typeOfRelation != RelationTypeConstants.FAVORITE) {
                var singletonSet = new HashSet<int> { userId };
                await RemoveUserToObjectRelations<TRelation>(singletonSet, objectIds, typeOfRelation);
            }
            var entities = objectIds.Select(objectId => new TRelation
            {
                UserId = userId,
                RelatedObjectId = objectId,
                TypeOfRelation = typeOfRelation
            }).ToList();
            await _dbContext.Set<TRelation>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }
        
        public async Task RemoveUserToObjectRelations<TRelation>(ISet<int> userIds, ISet<int> objectIds, string? relationType)
            where TRelation : Relation
        {
            var relations = _dbContext.Set<TRelation>()
                .Where(relation => relationType == null || relationType == relation.TypeOfRelation)
                .Where(relation => userIds.Contains(relation.UserId))
                .Where(relation => objectIds.Contains(relation.RelatedObjectId))
                .ToList();
            if (relations.Count == 0)
            {
                return;
            }
            _dbContext.Set<TRelation>().RemoveRange(relations);
            await _dbContext.SaveChangesAsync();
        }

        public bool UserExists(int userId)
        {
            return _dbContext.Users.Where(user => user.Id == userId).Any();
        }
    }
}
