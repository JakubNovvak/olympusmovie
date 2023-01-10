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
        [Column("title")]
        public string Title { get; set; } = null!;
        [Column("number")]
        public int Number { get; set; }
        [Column("description")]
        public string Description { get; set; } = null!;
        [Column("release_date")]
        public DateTime ReleaseDate { get; set; }
        [Column("cover")]
        public string Cover { get; set; } = null!;
        [Column("background_image")]
        public string BackgroundImage { get; set; } = null!;
        [Column("thumbnail")]
        public string Thumbnail { get; set; } = null!;
        [Column("trailer")]
        public string Trailer { get; set; } = null!;
        
        public virtual ICollection<Episode> Episodes { get; set; } = null!;
        public virtual ICollection<Review> Reviews { get; set; } = null!;
        public virtual ICollection<Rating> Rating { get; set; } = null!;
        public virtual ICollection<Genre> Genres { get; set; } = null!;
        public virtual ICollection<Tag> Tags { get; set; } = null!;
        public virtual ICollection<ParticipantSeason> Participants { get; set; } = null!;
    }
}
