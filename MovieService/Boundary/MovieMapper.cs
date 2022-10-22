using MovieService.ApiModel;
using MovieService.Control;

namespace MovieService.Boundary
{
    public static class MovieMapper
    {
        public static MovieDTO MapToDTO(MovieWrapper movieWrapper)
        {
            return new MovieDTO
            {
                Id = movieWrapper.Id ?? 0,
                DateOfRelease = movieWrapper.DateOfRelease,
                Description = movieWrapper.Description
            };
        }

        public static MovieWrapper MapToWrapper(MovieDTO movie)
        {
            return new MovieWrapper
            {
                Id = movie.Id,
                DateOfRelease = movie.DateOfRelease,
                Description = movie.Description
            };
        }
    }
}
