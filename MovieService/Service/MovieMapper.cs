using MovieService.ApiModel;
using MovieService.Model;
using System;

namespace MovieService.Service
{
    public static class MovieMapper
    {
        public static MovieDTO MapToDTO(Movie movie)
        {
            return new MovieDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                DateOfRelease = movie.DateOfRelease,
                DurationInMinutes = movie.DurationInMinutes,
                Photo = movie.Photo,
                Trailer = movie.Trailer
            };
        }

        public static MovieDetailsDTO MapToDerailsDTO(Movie movie)
        {
            List<GenreDTO> genresDTO = new List<GenreDTO>();
            foreach (Genre genre in movie.Genres)
            {
                genresDTO.Add(GenreMapper.MapToDTO(genre));
            }

            List<TagDTO> tagsDTO = new List<TagDTO>();
            foreach (Tag tag in movie.Tags)
            {
                tagsDTO.Add(TagMapper.MapToDTO(tag));
            }

            List<PersonDTO> personsDTO = new List<PersonDTO>();
            foreach (Person person in movie.Persons)
            {
                personsDTO.Add(PersonMapper.MapToDTO(person));
            }

            return new MovieDetailsDTO
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                DateOfRelease = movie.DateOfRelease,
                DurationInMinutes = movie.DurationInMinutes,
                Photo = movie.Photo,
                Trailer = movie.Trailer,
                Genres = genresDTO,
                Tags = tagsDTO,
                Persons = personsDTO
            };
        }

        public static Movie MapToEntity(MovieDTO movieDTO, bool isNew)
        {
            if (isNew)
            {
                return new Movie
                {
                    Id = movieDTO.Id,
                    Title = movieDTO.Title,
                    Description = movieDTO.Description,
                    DateOfRelease = movieDTO.DateOfRelease,
                    DurationInMinutes = movieDTO.DurationInMinutes,
                    Photo = movieDTO.Photo,
                    Trailer = movieDTO.Trailer,
                    Genres = new List<Genre>(),
                    Tags = new List<Tag>(),
                    Persons = new List<Person>()
                };
            } 
            else
            {
                return new Movie
                {
                    Id = movieDTO.Id,
                    Title = movieDTO.Title,
                    Description = movieDTO.Description,
                    DateOfRelease = movieDTO.DateOfRelease,
                    DurationInMinutes = movieDTO.DurationInMinutes,
                    Photo = movieDTO.Photo,
                    Trailer = movieDTO.Trailer
                };
            };
        }
    }
}
