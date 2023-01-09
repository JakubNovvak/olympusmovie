using MovieService.ApiModel.Roles;

namespace MovieService.Service.Roles
{
    public interface IRoleDataService
    {
        IEnumerable<int> GetAll();
        Task<RoleDTO?> GetById(int id);
        Task<int> AddAsync(RoleDTO roleDTO);
        Task<int> EditAsync(RoleDTO roleDTO);
        Task<bool> RemoveRange(ISet<int> ids);
    }
}
