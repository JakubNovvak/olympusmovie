using MovieService.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.ApiModel
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Content { get; set; } = null!;
        public ICollection<CommentDTO> Comments { get; set; } = null!;
    }
}
