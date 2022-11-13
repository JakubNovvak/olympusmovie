using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieService.Model
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
        public DateOnly Birthdate { get; set; }

        [Column("series")]
        public ICollection<Series>? Series { get; set; }

        [Column("movies")]
        public ICollection<Movie>? Movies { get; set; }

        [Column("roles")]
        public ICollection<Role>? Roles { get; set; }
    }
}
