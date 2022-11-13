using MovieService.ApiModel;
using MovieService.Service;

namespace MovieService.Controller
{
    public static class MovieMapper
    {
        public static MovieDTO MapToDTO(MovieWrapper movieWrapper)
        {
            return new MovieDTO
            {
                Id = movieWrapper.Id,
                Title = movieWrapper.Title,
                Description = movieWrapper.Description,
                DateOfRelease = movieWrapper.DateOfRelease,
                Duration = movieWrapper.Duration
            };
        }

        public static MovieWrapper MapToWrapper(MovieDTO movie)
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
    }
}
