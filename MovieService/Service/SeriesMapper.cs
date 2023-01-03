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

            List<SeasonsDTO> seasonsDTO = new List<SeasonsDTO>();
            foreach (Season season in series.Seasons)
            {
                seasonsDTO.Add(SeasonMapper.MapToDTO(season));
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
                Trailer = series.Trailer,
                Genres = genresDTO,
                Tags = tagsDTO,
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
                Persons = new List<Person>()
            };
        }
    }
}
