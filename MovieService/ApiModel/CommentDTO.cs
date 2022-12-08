using MovieService.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.ApiModel
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int ReviewId { get; set; }
    }
}
