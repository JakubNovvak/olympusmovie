using MovieService.ApiModel.Movies;
using MovieService.ApiModel.Persons;
using MovieService.ApiModel.Roles;
using MovieService.ApiModel.Seasons;
using MovieService.Model;

namespace MovieService.ApiModel.Participants
{
    public class ParticipantDTO
    {
        public int? MovieId { get; set; }
        public MovieDTO? Movie { get; set; }
        public int? SeasonId { get; set; }
        public SeasonDTO? Season { get; set; }

        public int PersonId { get; set; }
        public PersonDTO Person { get; set; } = null!;
        public int RoleId { get; set; }
        public RoleDTO Role { get; set; } = null!;
    }
}
