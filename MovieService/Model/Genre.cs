using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieService.Model
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("description")]
        public string Description { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; set; } = null!;

        public virtual ICollection<Series> Series { get; set; } = null!;
    }
}
