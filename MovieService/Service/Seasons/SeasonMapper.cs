using MovieService.ApiModel.Common;
using MovieService.ApiModel.Seasons;
using MovieService.Model;
using MovieService.Service.Episodes;
using MovieService.Service.Genres;
using MovieService.Service.Participants;
using MovieService.Service.Reviews;
using MovieService.Service.Tags;

namespace MovieService.Service.Seasons
{
    public class SeasonMapper
    {
        public static SeasonDTO MapToDTO(Season season)
        {
            return new SeasonDTO
            {
                Id = season.Id,
                Title = season.Title,
                Number = season.Number,
                Description = season.Description,
                ReleaseDate = new DateDTO(season.ReleaseDate.Year, season.ReleaseDate.Month, season.ReleaseDate.Day),
                Cover = season.Cover,
                BackgroundImage = season.BackgroundImage,
                Thumbnail = season.Thumbnail,
                Trailer = season.Trailer,
            };
        }

        public static SeasonDetailsDTO MapToDetailedDTO(Season season)
        {
            return new SeasonDetailsDTO
            {
                Id = season.Id,
                Title = season.Title,
                Number = season.Number,
                Description = season.Description,
                ReleaseDate = new DateDTO(season.ReleaseDate.Year, season.ReleaseDate.Month, season.ReleaseDate.Day),
                Cover = season.Cover,
                BackgroundImage = season.BackgroundImage,
                Thumbnail = season.Thumbnail,
                Trailer = season.Trailer,
                AverageRating = season.Rating.Count != 0 ? season.Rating.Average(rating => rating.Value) : null,
                NumberOfRating = season.Rating.Count,
                Episodes = season.Episodes.Select(EpisodeMapper.MapToDTO).ToList(),
                Reviews = season.Reviews.Select(ReviewMapper.MapToDTO).ToList(),
                Genres = season.Genres.Select(GenreMapper.MapToDTO).ToList(),
                Tags = season.Tags.Select(TagMapper.MapToDTO).ToList(),
                Participants = season.Participants.Select(ParticipantMapper.MapToDTO).ToList(),
            };
        }

        public static Season MapToEntity(SeasonDTO seasonDTO)
        {
            return new Season
            {
                Id = seasonDTO.Id,
                Title = seasonDTO.Title,
                Number = seasonDTO.Number,
                Description = seasonDTO.Description,
                ReleaseDate = new DateTime(seasonDTO.ReleaseDate.Year, seasonDTO.ReleaseDate.Month, seasonDTO.ReleaseDate.Day),
                Cover = seasonDTO.Cover,
                BackgroundImage = seasonDTO.BackgroundImage,
                Thumbnail = seasonDTO.Thumbnail,
                Trailer = seasonDTO.Trailer,
            };
        }
    }
}
