using MovieService.ApiModel;

namespace MovieService.Service
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
