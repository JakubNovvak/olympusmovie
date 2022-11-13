using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MovieService.Entities;

namespace MovieService.Entity
{
    [Table("genre", Schema = "dbo")]
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("description")]
        public string? Description { get; set; }

        [Column("Movies")]
        public ICollection<Movie>? Movies { get; set; }

        [Column("Series")]
        public ICollection<Series>? Series { get; set; }
    }
}
