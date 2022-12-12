namespace MovieService.ApiModel
{
    public class SeriesDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Photo { get; set; } = null!;
        public string Trailer { get; set; } = null!;
    }
}
