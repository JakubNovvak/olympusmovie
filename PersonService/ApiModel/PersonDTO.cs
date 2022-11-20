using PersonService.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonService.ApiModel
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public DateTime Birthdate { get; set; }
        public virtual List<PersonMovie> SeriesId { get; set; } = null!;
        //public virtual ICollection<int> MoviesId { get; set; } = null!;
        public virtual ICollection<Role> Roles { get; set; } = null!;
    }
}
