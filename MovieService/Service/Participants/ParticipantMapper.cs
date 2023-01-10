using MovieService.ApiModel.Participants;
using MovieService.ApiModel.Seasons;
using MovieService.Infrastructure;
using MovieService.Model;
using MovieService.Service.Movies;
using MovieService.Service.Persons;
using MovieService.Service.Roles;
using MovieService.Service.Seasons;

namespace MovieService.Service.Participants
{
    public static class ParticipantMapper
    {
        public static ParticipantMovie MapToEntity(ParticipantMovieCreateDTO participantDTO, int movieId)
        {
            return new ParticipantMovie
            {
                MovieId = movieId,
                PersonId = participantDTO.PersonId,
                RoleId = participantDTO.RoleId
            };
        }

        public static ParticipantSeason MapToEntity(ParticipantSeasonCreateDTO participantDTO, int seasonId)
        {
            return new ParticipantSeason
            {
                SeasonId = seasonId,
                PersonId = participantDTO.PersonId,
                RoleId = participantDTO.RoleId
            };
        }

        public static ParticipantMovieDTO MapToDTO(ParticipantMovie participant)
        {
            return new ParticipantMovieDTO
            {
                Person = PersonMapper.MapToDTO(participant.Person),
                Role = RoleMapper.MapToDTO(participant.Role)
            };
        }

        public static ParticipantSeasonDTO MapToDTO(ParticipantSeason participant)
        {
            return new ParticipantSeasonDTO
            {
                Person = PersonMapper.MapToDTO(participant.Person),
                Role = RoleMapper.MapToDTO(participant.Role)
            };
        }
    }
}
