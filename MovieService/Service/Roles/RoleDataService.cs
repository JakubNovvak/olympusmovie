using Microsoft.EntityFrameworkCore;
using MovieService.ApiModel.Roles;
using MovieService.Model;
using MovieService.Repository;

namespace MovieService.Service.Roles
{
    public class RoleDataService : IRoleDataService
    {
        private readonly MovieDbContext _dbContext;

        public RoleDataService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(RoleDTO roleDTO)
        {
            var role = RoleMapper.MapToEntity(roleDTO);
            var createRole = await _dbContext.Set<Role>().AddAsync(role);
            
            if (createRole == null)
            {
                return 0;
            }

            await _dbContext.SaveChangesAsync();
            return createRole.Entity.Id;

        }

        public async Task<int> EditAsync(RoleDTO roleDTO)
        {
            var roleEntity = RoleMapper.MapToEntity(roleDTO);
            var foundRole = await _dbContext.Set<Role>().FindAsync(roleEntity.Id);
            if (foundRole == null)
            {
                return 0;
            }

            foundRole.Name = roleEntity.Name;
            await _dbContext.SaveChangesAsync();
            
            return foundRole.Id;

        }

        public IEnumerable<RoleDTO> GetAll()
        {
            return _dbContext.Set<Role>().Select(role => RoleMapper.MapToDTO(role));
        }

        public async Task<RoleDTO?> GetById(int id)
        {
            var role = await _dbContext.Set<Role>().FindAsync(id);
            if (role == null)
            {
                return null;
            }
            return RoleMapper.MapToDTO(role);
        }

        public async Task<bool> RemoveRange(ISet<int> id)
        {
            var roles = _dbContext.Set<Role>().Where(role => id.Contains(role.Id)).ToList();
            if (roles.Count == 0)
            {
                return false;
            }
            _dbContext.Set<Role>().RemoveRange(roles);
            await _dbContext.SaveChangesAsync();
            
            return true;
        }
    }
}
