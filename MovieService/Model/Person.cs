using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieService.Model
{
    [Table("person", Schema = "dbo")]
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

        [Column("photo")]
        public string Photo { get; set; } = null!;

        public virtual ICollection<Series> Series { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; } = null!;

        public virtual ICollection<Role> Roles { get; set; } = null!;
    }
}
