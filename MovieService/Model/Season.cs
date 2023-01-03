using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.Model
{
    public class Season
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("number")]
        public int Number { get; set; }

        [Column("title")]
        public string Title { get; set; } = null!;

        [Column("series_id")]
        public int SeriesId { get; set; }

        public virtual Series Series { get; set; } = null!;

        public virtual ICollection<Episode> Episodes { get; set; } = null!;
    }
}
