using MovieService.ApiModel.Common;
using MovieService.ApiModel.Episodes;
using MovieService.Model;

namespace MovieService.Service.Episodes
{
    public class EpisodeMapper
    {
        public static EpisodeDTO MapToDTO(Episode episode)
        {
            return new EpisodeDTO
            {
                Id = episode.Id,
                EpisodeNumber = episode.EpisodeNumber,
                Title = episode.Title,
                ReleaseDate = new DateDTO(episode.ReleaseDate.Year, episode.ReleaseDate.Month, episode.ReleaseDate.Day),
                DurationInMinutes = episode.DurationInMinutes,
                Description = episode.Description,
                SeasonId = episode.SeasonId,
            };
        }

        public static Episode MapToEntity(EpisodeDTO episodeDTO)
        {
            return new Episode
            {
                Id = episodeDTO.Id,
                EpisodeNumber = episodeDTO.EpisodeNumber,
                Title = episodeDTO.Title,
                ReleaseDate = new DateTime(episodeDTO.ReleaseDate.Year, episodeDTO.ReleaseDate.Month, episodeDTO.ReleaseDate.Day),
                DurationInMinutes = episodeDTO.DurationInMinutes,
                Description = episodeDTO.Description,
                SeasonId = episodeDTO.SeasonId,
            };
        }
    }
}
