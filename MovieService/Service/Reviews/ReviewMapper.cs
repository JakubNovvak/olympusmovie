using MovieService.ApiModel.Reviews;
using MovieService.Model;
using MovieService.Service.Comments;

namespace MovieService.Service.Reviews
{
    public class ReviewMapper
    {
        public static ReviewDTO MapToDTO(Review review)
        {
            return new ReviewDTO
            {
                Id = review.Id,
                Content = review.Content,
                UserId = review.UserId,
                RatingId = review.RatingId,
                Comments = review.Comments.Select(CommentMapper.MapToDTO).ToList()
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
