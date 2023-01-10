using MovieService.ApiModel.Movies;
using MovieService.ApiModel.Persons;
using MovieService.ApiModel.Roles;
using MovieService.ApiModel.Seasons;
using MovieService.Model;

namespace MovieService.ApiModel.Participants
{
    public class ParticipantSeasonDTO
    {
        public PersonDTO Person { get; set; } = null!;
        public RoleDTO Role { get; set; } = null!;
    }
}
