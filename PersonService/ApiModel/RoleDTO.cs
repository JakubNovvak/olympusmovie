using PersonService.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonService.ApiModel
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
