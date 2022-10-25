namespace MovieService.ApiModel
{
    public class LinkDTO
    {
        public string Href { get; }
        public string Rel { get; }
        public string Method { get; }

        public LinkDTO()
        {
            Href = string.Empty;
            Rel = string.Empty;
            Method = string.Empty;
        }

        public LinkDTO(string href, string rel, string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }
    }
}
