using MovieService.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.ApiModel
{
    public class SeasonsDTO
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Title { get; set; } = null!;
        public int SeriesId { get; set; }
        public virtual ICollection<EpisodeDTO> Episodes { get; set; } = null!;
    }
}
