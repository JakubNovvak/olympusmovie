using MovieService.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieService.ApiModel
{
    public class MovieDetailsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateOnly DateOfRelease { get; set; }
        public int DurationInMinutes { get; set; }
        public string Photo { get; set; } = null!;
        public string Trailer { get; set; } = null!;
        public ICollection<GenreDTO> Genres { get; set; } = null!;
        public ICollection<TagDTO> Tags { get; set; } = null!;
        public ICollection<PersonDTO> Persons { get; set; } = null!;
    }
}
