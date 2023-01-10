using MovieService.ApiModel.Common;
using MovieService.ApiModel.Participants;
using MovieService.Model;

namespace MovieService.ApiModel.Seasons
{
    public class SeasonCreateEditDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int Number { get; set; }
        public string Description { get; set; } = null!;
        public virtual DateDTO ReleaseDate { get; set; } = null!;
        public string Cover { get; set; } = null!;
        public string BackgroundImage { get; set; } = null!;
        public string Thumbnail { get; set; } = null!;
        public string Trailer { get; set; } = null!;
        public ICollection<int> GenreIds { get; set; } = null!;
        public ICollection<int> TagIds { get; set; } = null!;
        public ICollection<ParticipantSeasonCreateDTO> Participants { get; set; } = null!;
    }
}
