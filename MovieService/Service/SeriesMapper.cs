using MovieService.Model;
using MovieService.ApiModel;

namespace MovieService.Service
{
    public class SeriesMapper
    {
        public static SeriesDTO MapToDTO(Series series)
        {
            return new SeriesDTO
            {
                Id = series.Id,
                Title = series.Title,
                Description = series.Description,
                Photo = series.Photo
            };
        }

        public static SeriesDetailsDTO MapToDetailsDTO(Series series)
        {
            List<GenreDTO> genresDTO = new List<GenreDTO>();
            foreach(Genre genre in series.Genres)
            {
                genresDTO.Add(GenreMapper.MapToDTO(genre));
            }    

            List<TagDTO> tagsDTO = new List<TagDTO>();
            foreach (Tag tag in series.Tags)
            {
                tagsDTO.Add(TagMapper.MapToDTO(tag));
            }

            List<EpisodeDTO> episodesDTO = new List<EpisodeDTO>();
            foreach (Episode episode in series.Episodes)
            {
                episodesDTO.Add(EpisodeMapper.MapToDTO(episode));
            }

            List<PersonDTO> personsDTO = new List<PersonDTO>();
            foreach (Person person in series.Persons)
            {
                personsDTO.Add(PersonMapper.MapToDTO(person));
            }

            return new SeriesDetailsDTO
            {
                Id = series.Id,
                Title = series.Title,
                Description = series.Description,
                Photo = series.Photo,
                Genres = genresDTO,
                Tags = tagsDTO,
                Episodes = episodesDTO,
                Persons = personsDTO
            };
        }

        public static Series MapToEntity(SeriesDTO seriesDTO)
        {
            return new Series
            {
                Id = seriesDTO.Id,
                Title = seriesDTO.Title,
                Description = seriesDTO.Description,
                Photo = seriesDTO.Photo,
                Genres = new List<Genre>(),
                Tags = new List<Tag>(),
                Episodes = new List<Episode>(),
                Persons = new List<Person>()
            };
        }
    }
}
