using MovieService.ApiModel.Comments;
using MovieService.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.ApiModel.Reviews
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int UserId { get; set; }
        public int RatingId { get; set; }
        public ICollection<CommentDTO> Comments { get; set; } = null!;
    }
}
