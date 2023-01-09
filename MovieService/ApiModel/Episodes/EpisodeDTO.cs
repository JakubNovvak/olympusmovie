using MovieService.ApiModel.Common;
using MovieService.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.ApiModel.Episodes
{
    public class EpisodeDTO
    {
        public int Id { get; set; }
        public int EpisodeNumber { get; set; }
        public string Title { get; set; } = null!;
        public virtual DateDTO ReleaseDate { get; set; } = null!;
        public int DurationInMinutes { get; set; }
        public string Description { get; set; } = null!;
        public int SeasonId { get; set; }
    }
}
