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
                ReleaseDate = episode.ReleaseDate,
                DurationInMinutes = episode.DurationInMinutes,
                Description = episode.Description
            };
        }

        public static Episode MapToEntity(EpisodeDTO episodeDTO, bool isNew)
        {
            if (isNew)
            {
                return new Episode
                {
                    Id = episodeDTO.Id,
                    Season = episodeDTO.Season,
                    EpisodeNumber = episodeDTO.EpisodeNumber,
                    Title = episodeDTO.Title,
                    ReleaseDate = episodeDTO.ReleaseDate,
                    DurationInMinutes = episodeDTO.DurationInMinutes,
                    Description = episodeDTO.Description,
                    SeriesId = new int(),
                    Series = new Series()
                };
            }
            else
            {
                return new Episode
                {
                    Id = episodeDTO.Id,
                    Season = episodeDTO.Season,
                    EpisodeNumber = episodeDTO.EpisodeNumber,
                    Title = episodeDTO.Title,
                    ReleaseDate = episodeDTO.ReleaseDate,
                    DurationInMinutes = episodeDTO.DurationInMinutes,
                    Description = episodeDTO.Description
                };
            }
        }
    }
}
