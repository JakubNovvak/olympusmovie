using MovieService.ApiModel;
using MovieService.Model;

namespace MovieService.Service
{
    public class SeasonMapper
    {
        public static SeasonsDTO MapToDTO(Season season)
        {
            List<EpisodeDTO> episodesDTO = new List<EpisodeDTO>();
            foreach (Episode episode in season.Episodes)
            {
                episodesDTO.Add(EpisodeMapper.MapToDTO(episode));
            }

            return new SeasonsDTO
            {
                Id = season.Id,
                Number = season.Number,
                Title = season.Title,
                SeriesId = season.SeriesId,
                Episodes = episodesDTO,
            };
        }

        public static Season MapToEntity(SeasonsDTO seasonsDTO)
        {
            return new Season
            {
                Id = seasonsDTO.Id,
                Number = seasonsDTO.Number,
                Title = seasonsDTO.Title,
                SeriesId = seasonsDTO.SeriesId,
            };

        }
    }
}
