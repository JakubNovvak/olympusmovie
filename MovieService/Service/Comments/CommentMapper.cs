using MovieService.ApiModel.Comments;
using MovieService.Model;

namespace MovieService.Service.Comments
{
    public class CommentMapper
    {
        public static CommentDTO MapToDTO(Comment comment)
        {
            return new CommentDTO
            {
                Id = comment.Id,
                UserId = comment.UserId,
                RatingId = comment.RatingId,
                Content = comment.Content,
                ReviewId = comment.ReviewId,
            };
        }

        public static Comment MapToEntity(CommentDTO commentDTO)
        {
            return new Comment
            {
                Id = commentDTO.Id,
                UserId = commentDTO.UserId,
                RatingId = commentDTO.RatingId,
                Content = commentDTO.Content,
                ReviewId = commentDTO.ReviewId,
            };
        }
    }
}
