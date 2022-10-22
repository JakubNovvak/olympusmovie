using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieService.ApiModel;
using MovieService.Control;
using MovieService.Entities;

namespace MovieService.Boundary
{
    [Route($"api/movies")]
    [ApiController]
    public class MovieResource : ControllerBase
    {
        private readonly IMovieDataService _dataService;

        public MovieResource(IMovieDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieDTO>> GetMovies()
        {
            return Ok(_dataService.GetAll().Select(MovieMapper.MapToDTO).AsEnumerable());
        }

        [HttpPost]
        public async Task<ActionResult> Create(MovieDTO movieDTO)
        {
            var movieWrapper = MovieMapper.MapToWrapper(movieDTO);
            await _dataService.AddAsync(movieWrapper);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var removingResult = await _dataService.Remove(id);
            if (removingResult == false)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
