using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MovieService.Model
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("content")]
        public string Content { get; set; } = null!;

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("rating_id")]
        public int RatingId { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = null!;
    }
}
