using MovieService.ApiModel;
using MovieService.Model;

namespace MovieService.Service
{
    public class EpisodeMapper
    {
        public static EpisodeDTO MapToDTO(Episode episode)
        {
            return new EpisodeDTO
            {
                Id = episode.Id,
                Season = episode.Season,
                EpisodeNumber = episode.EpisodeNumber,
                Title = episode.Title,
                ReleaseDate = DateOnly.FromDateTime(episode.ReleaseDate),
                DurationInMinutes = episode.DurationInMinutes,
                Description = episode.Description
            };
        }

        public static Episode MapToEntity(EpisodeDTO episodeDTO)
        {
            return new Episode
            {
                Id = episodeDTO.Id,
                Season = episodeDTO.Season,
                EpisodeNumber = episodeDTO.EpisodeNumber,
                Title = episodeDTO.Title,
                ReleaseDate = episodeDTO.ReleaseDate.ToDateTime(TimeOnly.Parse("01:00 PM")),
                DurationInMinutes = episodeDTO.DurationInMinutes,
                Description = episodeDTO.Description,
                SeriesId = new int(),
                Series = new Series()
            };
        }
    }
}
