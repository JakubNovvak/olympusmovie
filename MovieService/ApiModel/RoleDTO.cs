using MovieService.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.ApiModel
{
    public class RoleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
