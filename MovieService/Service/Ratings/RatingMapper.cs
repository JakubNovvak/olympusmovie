using MovieService.ApiModel.Ratings;
using MovieService.Infrastructure;
using MovieService.Model;

namespace MovieService.Service.Ratings
{
    public class RatingMapper
    {
        public static RatingDTO MapToDTO(Rating rating)
        {
            return new RatingDTO
            {
                Id = rating.Id,
                value = rating.Value,
                UserId = rating.UserId,
                PositionId = (rating.MovieId ?? rating.SeasonId)!.Value,
                PositionType = rating.MovieId != null ? PositionTypeConstants.MOVIE : PositionTypeConstants.SEASON,
            };
        }

        public static Rating MapToEntity(RatingDTO ratingDTO)
        {
            return new Rating
            {
                Id = ratingDTO.Id,
                Value = ratingDTO.value,
                UserId = ratingDTO.UserId,
                SeasonId = ratingDTO.PositionType == PositionTypeConstants.SEASON ? ratingDTO.PositionId : null,
                MovieId = ratingDTO.PositionType == PositionTypeConstants.MOVIE ? ratingDTO.PositionId : null,
            };
        }
    }
}
