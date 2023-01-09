using MovieService.ApiModel.Genres;
using MovieService.Model;

namespace MovieService.Service.Genres
{
    public class GenreMapper
    {
        public static GenreDTO MapToDTO(Genre genre)
        {
            return new GenreDTO
            {
                Id = genre.Id,
                Name = genre.Name,
                Description = genre.Description
            };
        }

        public static Genre MapToEntity(GenreDTO genreDTO)
        {
            return new Genre
            {
                Id = genreDTO.Id,
                Name = genreDTO.Name,
                Description = genreDTO.Description,
                Movies = new List<Movie>(),
                Seasons = new List<Season>()
            };
        }
    }
}
