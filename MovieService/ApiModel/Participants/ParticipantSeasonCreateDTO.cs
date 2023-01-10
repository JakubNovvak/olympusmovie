using MovieService.ApiModel.Movies;
using MovieService.ApiModel.Persons;
using MovieService.ApiModel.Roles;

namespace MovieService.ApiModel.Participants
{
    public class ParticipantSeasonCreateDTO
    {
        public int PersonId { get; set; }
        public int RoleId { get; set; }
    }
}
