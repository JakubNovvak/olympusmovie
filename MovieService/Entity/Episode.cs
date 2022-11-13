using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.Entity
{
    [Table("episode", Schema = "dbo")]
    public class Episode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("season")]
        public int Season { get; set; }

        [Column("episode_number")]
        public int EpisodeNumber { get; set; }

        [Column("title")]
        public string? Title { get; set; }

        [Column("release_date")]
        public DateOnly ReleaseDate { get; set; }

        [Column("duration")]
        public TimeSpan Duration { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("series_id")]
        public int SeriesId { get; set; }

        [Column("")]
        public virtual Series Series { get; set; } = null!;
    }
}
