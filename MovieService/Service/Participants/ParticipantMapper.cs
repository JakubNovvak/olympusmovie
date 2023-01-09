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
        public static Participant MapToEntity(ParticipantDTO participantDTO)
        {
            return new Participant
            {
                MovieId = participantDTO.MovieId,
                SeasonId = participantDTO.SeasonId,
                PersonId = participantDTO.PersonId,
                RoleId = participantDTO.RoleId
            };
        }

        public static Participant MapToEntity(CreateEditParticipantDTO participantDTO)
        {
            return new Participant
            {
                MovieId = participantDTO.PositionType == PositionTypeConstants.MOVIE ? participantDTO.PositionId : null,
                SeasonId = participantDTO.PositionType == PositionTypeConstants.SEASON ? participantDTO.PositionId : null,
                PersonId = participantDTO.PersonId,
                RoleId = participantDTO.RoleId
            };
        }

        public static ParticipantDTO MapToDTO(Participant participant)
        {
            return new ParticipantDTO
            {
                MovieId = participant.MovieId,
                Movie = participant.MovieId != null ? MovieMapper.MapToDTO(participant.Movie!) : null,
                SeasonId = participant.SeasonId,
                Season = participant.SeasonId != null ? SeasonMapper.MapToDTO(participant.Season!) : null,
                PersonId = participant.PersonId,
                Person = PersonMapper.MapToDTO(participant.Person),
                RoleId = participant.RoleId,
                Role = RoleMapper.MapToDTO(participant.Role)
            };
        }
    }
}
