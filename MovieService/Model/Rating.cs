using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.Model
{
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("value")]
        public int Value { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("movie_id")]
        public int? MovieId { get; set; }
        public virtual Movie? Movie { get; set; }
        
        [Column("season_id")]
        public int? SeasonId { get; set; }
        public virtual Season? Season { get; set; }
    }
}
