using PersonService.ApiModel;
using PersonService.Model;

namespace PersonService.Service
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

        public static Role MapToEntity(RoleDTO role)
        {
            return new Role()
            {
                Id = role.Id,
                Name = role.Name,
                Persons = new List<Person>()
            };
        }
    }
}
