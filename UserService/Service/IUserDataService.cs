using UserService.ApiModel;
using UserService.Model.Relations;

namespace UserService.Service
{
    public interface IUserDataService
    {
        Task<int> AddAsync(UserDTO userDTO);
        Task<bool> Remove(int id);
        Task<UserDTO?> GetById(int id);
        Task<int> ChangeAccountData(UserDTO userDTO);
        bool UserExists(int userId);
        Task RemoveUserToObjectRelations<TRelation>(ISet<int> userIds, ISet<int> objectIds, string? relationType) where TRelation : Relation;
        List<int> GetUserRelatedObjectIds<TRelation>(int userId, string typeOfRelation) where TRelation : Relation;
        Task SyncUserToObjectRelations<TRelation>(int userId, ISet<int> objectIds, string typeOfRelation) where TRelation : Relation, new();
    }
}
