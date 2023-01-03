using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.Model
{
    public class Episode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("episode_number")]
        public int EpisodeNumber { get; set; }

        [Column("title")]
        public string Title { get; set; } = null!;

        [Column("release_date")]
        public DateTime ReleaseDate { get; set; }

        [Column("duration_in_minutes")]
        public int DurationInMinutes { get; set; }

        [Column("description")]
        public string Description { get; set; } = null!;

        [Column("series_id")]
        public int SeasonId { get; set; }

        public virtual Season Season { get; set; } = null!;
    }
}
