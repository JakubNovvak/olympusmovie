using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PersonService.Model
{
    [Table("Person", Schema = "dbo")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("surname")]
        public string Surname { get; set; } = null!;

        [Column("birthdate")]
        public DateTime Birthdate { get; set; }

        [Column("series")]
        public virtual List<PersonMovie> SeriesId { get; set; } = null!;

        //[Column("movies")]
        //public virtual ICollection<int> MoviesId { get; set; } = null!;

        [Column("roles")]
        public virtual ICollection<Role> Roles { get; set; } = null!;
    }
}
