using MovieService.Model;

namespace MovieService.ApiModel
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime DateOfRelease { get; set; }
        public int DurationInMinutes { get; set; }
        public string Photo { get; set; } = null!;
        public string Trailer { get; set; } = null!;
    }
}
