using MovieService.ApiModel;
using MovieService.Model;

namespace MovieService.Service
{
    public class ReviewMapper
    {
        public static ReviewDTO MapToDTO(Review review)
        {
            List<CommentDTO> commentsDTO = new List<CommentDTO>();
            foreach (Comment comment in review.Comments)
            {
                commentsDTO.Add(CommentMapper.MapToDTO(comment));
            }


            return new ReviewDTO
            {
                Id = review.Id,
                Content = review.Content,
                UserId = review.UserId,
                RatingId = review.RatingId,
                Comments = commentsDTO
            };
             
        }

        public static Review MapToEntity(ReviewDTO reviewDTO)
        {
            return new Review
            {
                Id = reviewDTO.Id,
                Content = reviewDTO.Content,
                UserId = reviewDTO.UserId,
                RatingId = reviewDTO.RatingId,
                Comments = new List<Comment>()
            };
        }
    }
}
