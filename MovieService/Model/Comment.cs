using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieService.Model
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("rating_id")]
        public int RatingId { get; set; }

        public virtual Rating Rating { get; set; } = null!;

        [Column("content")]
        public string Content { get; set; } = null!;

        [Column("review_id")]
        public int ReviewId { get; set; }

        public virtual Review Review { get; set; } = null!;
    }
}
