using MovieService.Model;

namespace MovieService.ApiModel
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public virtual DateDTO ReleaseDate { get; set; } = null!;
        public int DurationInMinutes { get; set; }
        public string Photo { get; set; } = null!;
        public string Trailer { get; set; } = null!;
    }
}
