using MovieService.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.ApiModel
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int UserId { get; set; }
        public int RatingId { get; set; }
        public virtual ICollection<CommentDTO> Comments { get; set; } = null!;
    }
}
