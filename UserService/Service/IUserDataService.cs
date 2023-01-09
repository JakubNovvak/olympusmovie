using Microsoft.AspNetCore.Mvc;
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
        Task<List<int>> SyncUserToObjectRelations(int userId, ISet<int> objectIds, string typeOfRelation, string typeOfPosition);
        List<int> GetUserRelatedObjectIds(int userId, string typeOfRelation, string typeOfPosition);
        Task SyncEpisodeCount(int userId, int[] seasonIds, int episodeCount);
        List<int> GetEpisodeCount(int userId, int seasonId);
        Task RemoveUserToObjectRelations(int userId, ISet<int> positionIds, List<string> relationTypes, string typeOfPosition);
    }
}
