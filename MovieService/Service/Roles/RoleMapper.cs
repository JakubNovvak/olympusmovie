using MovieService.ApiModel.Roles;
using MovieService.Model;

namespace MovieService.Service.Roles
{
    public class RoleMapper
    {
        public static RoleDTO MapToDTO(Role role)
        {
            return new RoleDTO
            {
                Id = role.Id,
                Name = role.Name
            };
        }

        public static Role MapToEntity(RoleDTO roleDTO)
        {
            return new Role
            {
                Id = roleDTO.Id,
                Name = roleDTO.Name,
                Persons = new List<Person>()
            };
        }
    }
}
