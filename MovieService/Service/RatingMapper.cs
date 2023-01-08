using MovieService.ApiModel;
using MovieService.Model;

namespace MovieService.Service
{
    public class RatingMapper
    {
        public static RatingDTO MapToDTO(Rating rating)
        {
            return new RatingDTO
            {
                Id = rating.Id,
                value = rating.value,
                UserId = rating.UserId,
                PositionId = rating.PositionId,
                PositionType = rating.PositionType,
            };
        }

        public static Rating MapToEntity(RatingDTO ratingDTO)
        {
            return new Rating
            {
                Id = ratingDTO.Id,
                value = ratingDTO.value,
                UserId = ratingDTO.UserId,
                PositionId = ratingDTO.PositionId,
                PositionType = ratingDTO.PositionType,
            };
        }


    }
}
