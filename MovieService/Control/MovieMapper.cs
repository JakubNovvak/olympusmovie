using MovieService.Entities;

namespace MovieService.Control
{
    public static class MovieMapper
    {
        public static MovieWrapper MapToWrapper(Movie movie)
        {
            return new MovieWrapper
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                DateOfRelease = movie.DateOfRelease,
                Duration = movie.Duration
            };
        }

        public static Movie MapToEntity(MovieWrapper movieWrapper)
        {
            return new Movie
            {
                Id = movieWrapper.Id ?? 0,
                Title = movieWrapper.Title,
                Description = movieWrapper.Description,
                DateOfRelease = movieWrapper.DateOfRelease,
                Duration = movieWrapper.Duration
            };
        }
    }
}
