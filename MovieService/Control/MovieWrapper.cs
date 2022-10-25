namespace MovieService.Control
{
    public class MovieWrapper
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public String? Description { get; set; }
        public DateTime? DateOfRelease { get; set; }
        public TimeSpan? Duration { get; set; }
    }
}
