using MovieService.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.ApiModel
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public virtual DateDTO Birthdate { get; set; } = null!;
        public string Photo { get; set; } = null!;
    }
}
