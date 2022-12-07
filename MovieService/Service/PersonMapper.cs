using MovieService.Model;
using MovieService.ApiModel;
using System;

namespace MovieService.Service
{
    public class PersonMapper
    {

        public static PersonDTO MapToDTO(Person person)
        {
            return new PersonDTO
            {
                Id = person.Id,
                Name = person.Name,
                Surname = person.Surname,
                Birthdate = DateOnly.FromDateTime(person.Birthdate),
                Photo = person.Photo
            };
        }

        public static PersonDetailsDTO MapToDetailsDTO(Person person)
        {
            List<SeriesDTO> seriesDTO = new List<SeriesDTO>();
            foreach (Series series in person.Series)
            {
                seriesDTO.Add(SeriesMapper.MapToDTO(series));
            }

            List<MovieDTO> moviesDTO = new List<MovieDTO>();
            foreach (Movie movie in person.Movies)
            {
                moviesDTO.Add(MovieMapper.MapToDTO(movie));
            }

            List<RoleDTO> rolesDTO = new List<RoleDTO>();
            foreach (Role role in person.Roles)
            {
                rolesDTO.Add(RoleMapper.MapToDTO(role));
            }

            return new PersonDetailsDTO
            {
                Id = person.Id,
                Name = person.Name,
                Surname = person.Surname,
                Birthdate = DateOnly.FromDateTime(person.Birthdate),
                Photo = person.Photo,
                Series = seriesDTO,
                Movies = moviesDTO,
                Roles = rolesDTO
            };
        }

        public static Person MapToEntity(PersonDTO personDTO)
        {
            return new Person
            {
                Id = personDTO.Id,
                Name = personDTO.Name,
                Surname = personDTO.Surname,
                Birthdate = personDTO.Birthdate.ToDateTime(TimeOnly.Parse("01:00 PM")),
                Photo =personDTO.Photo,
                Series = new List<Series>(),
                Movies = new List<Movie>(),
                Roles = new List<Role>()
            };
        }
    }
}
