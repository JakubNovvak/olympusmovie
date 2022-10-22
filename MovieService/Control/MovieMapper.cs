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
                DateOfRelease = movie.DateOfRelease,
                Description = movie.Description
            };
        }

        public static Movie MapToEntity(MovieWrapper movieWrapper)
        {
            return new Movie
            {
                Id = movieWrapper.Id ?? 0,
                DateOfRelease = movieWrapper.DateOfRelease,
                Description = movieWrapper.Description
            };
        }
    }
}
