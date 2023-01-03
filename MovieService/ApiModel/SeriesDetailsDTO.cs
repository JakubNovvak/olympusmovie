using MovieService.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.ApiModel
{
    public class SeriesDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public virtual DateDTO ReleaseDate { get; set; } = null!;
        public string Photo { get; set; } = null!;
        public string Trailer { get; set; } = null!;
        public double AverageRating { get; set; }
        public int NumberOfRating { get; set; }
        public virtual ICollection<GenreDTO> Genres { get; set; } = null!;
        public virtual ICollection<TagDTO> Tags { get; set; } = null!;
        public virtual ICollection<EpisodeDTO> Episodes { get; set; } = null!;
        public virtual ICollection<PersonDTO> Persons { get; set; } = null!;
    }
}
