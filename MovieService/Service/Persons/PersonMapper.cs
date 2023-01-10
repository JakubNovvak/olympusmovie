using MovieService.Model;
using System;
using MovieService.Service.Roles;
using MovieService.Service.Movies;
using MovieService.ApiModel.Common;
using MovieService.Service.Participants;
using MovieService.ApiModel.Persons;

namespace MovieService.Service.Persons
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
                Birthdate = new DateDTO(person.Birthdate.Year, person.Birthdate.Month, person.Birthdate.Day),
                Photo = person.Photo
            };
        }

        public static PersonDetailsDTO MapToDetailsDTO(Person person)
        {
            return new PersonDetailsDTO
            {
                Id = person.Id,
                Name = person.Name,
                Surname = person.Surname,
                Birthdate = new DateDTO(person.Birthdate.Year, person.Birthdate.Month, person.Birthdate.Day),
                Photo = person.Photo,
                MovieParticipants = person.MovieParticipants.Select(ParticipantMapper.MapToDTO).ToList(),
                SeasonParticipants = person.SeasonParticipants.Select(ParticipantMapper.MapToDTO).ToList()
            };
        }

        public static Person MapToEntity(PersonDTO personDTO)
        {
            return new Person
            {
                Id = personDTO.Id,
                Name = personDTO.Name,
                Surname = personDTO.Surname,
                Birthdate = new DateTime(personDTO.Birthdate.Year, personDTO.Birthdate.Month, personDTO.Birthdate.Day),
                Photo = personDTO.Photo,
                MovieParticipants = new List<ParticipantMovie>(),
                SeasonParticipants = new List<ParticipantSeason>()
            };
        }
    }
}
