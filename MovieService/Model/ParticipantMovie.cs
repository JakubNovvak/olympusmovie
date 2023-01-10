using MovieService.ApiModel.Movies;
using MovieService.ApiModel.Persons;
using MovieService.ApiModel.Roles;

namespace MovieService.Model
{
    public class ParticipantMovie
    {
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; } = null!;
        public int PersonId { get; set; }
        public virtual Person Person { get; set; } = null!;
        public int RoleId { get; set; }
        public virtual Role Role { get; set; } = null!;
    }
}
