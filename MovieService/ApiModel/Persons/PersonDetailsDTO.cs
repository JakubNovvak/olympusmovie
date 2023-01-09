using MovieService.ApiModel.Common;
using MovieService.ApiModel.Participants;

namespace MovieService.ApiModel.Persons
{
    public class PersonDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public DateDTO Birthdate { get; set; } = null!;
        public string Photo { get; set; } = null!;
        public ICollection<ParticipantDTO> Participants { get; set; } = null!;
    }
}
