using MovieService.Model;

namespace MovieService.ApiModel
{
    public class MovieDTO
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public String? Description { get; set; }
        public DateTime? DateOfRelease { get; set; }
        public Duration? Duration { get; set; }
        public ICollection<Genre>? Genres { get; set; }
        //public ICollection<Person>? Persons { get; set; }
        public ICollection<Tag>? Tags { get; set; }
    }
}
