using MovieService.ApiModel;
using MovieService.Repository;

namespace MovieService.Service
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
            var role = RoleMapper.MapToEntity(roleDTO, true);
            var createRole = await _dbContext.Roles.AddAsync(role);
            if (createRole != null)
            {
                await _dbContext.SaveChangesAsync();
                return createRole.Entity.Id;
            }
            return 0;
        }

        public async Task<int> EditAsync(RoleDTO roleDTO)
        {
            var roleEntity = RoleMapper.MapToEntity(roleDTO, false);
            var findRole = _dbContext.Roles.FirstOrDefault(role => role.Id == roleEntity.Id);
            if (findRole != null)
            {
                findRole.Name = roleEntity.Name;
                await _dbContext.SaveChangesAsync();
                return findRole.Id;
            }
            return 0;
        }

        public IEnumerable<int> GetAll()
        {
            return _dbContext.Roles.Select(role => role.Id);
        }

        public async Task<RoleDTO?> GetById(int id)
        {
            var role = await _dbContext.Roles.FindAsync(id);
            if(role == null)
            {
                return null;
            }
            return RoleMapper.MapToDTO(role);
        }

        public async Task<bool> RemoveRange(ISet<int> id)
        {
            var roles = _dbContext.Roles.Where(role => id.Contains(role.Id)).ToList();
            if(roles.Count == 0)
            {
                return false;
            }
            _dbContext.Roles.RemoveRange(roles);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
