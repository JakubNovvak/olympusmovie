using MovieService.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.ApiModel
{
    public class EpisodeDTO
    {
        public int Id { get; set; }
        public int Season { get; set; }
        public int EpisodeNumber { get; set; }
        public string Title { get; set; } = null!;
        public DateOnly ReleaseDate { get; set; }
        public int DurationInMinutes { get; set; }
        public string Description { get; set; } = null!;
    }
}
