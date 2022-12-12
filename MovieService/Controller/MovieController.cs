using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieService.ApiModel;
using MovieService.Service;

namespace MovieService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private const string ID_QUERY_PARAM = "id";
        private const string TITLE_QUERY_PARAM = "title";
        private const string GetMethod = "GET";
        private const string SelfRel = "self";
        private readonly IMovieDataService _dataService;
        private readonly LinkGenerator _linkGenerator;

        public MovieController(IMovieDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieDTO>> GetMovie(int id)
        {
            var movie = await _dataService.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieDTO>> GetMovies([FromQuery(Name = TITLE_QUERY_PARAM)] string? title)
        {
            IEnumerable<MovieDTO> movies = _dataService.GetAll();
            if (String.IsNullOrEmpty(title))
            {
                return Ok(movies);
            }
            return Ok(movies.Where(movie => movie.Title.ToLower().Contains(title.ToLower())));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create(MovieDTO movieDTO)
        {
            var id = await _dataService.AddAsync(movieDTO);
            var url = GetLinkToMovie(id);
            return Created(url.Href, url);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(MovieDTO movieDTO)
        {
            var id = await _dataService.EditAsync(movieDTO);
            var url = GetLinkToMovie(id);
            return Ok(url);
        }

        private LinkDTO GetLinkToMovie(int id)
        {
            var url = _linkGenerator.GetUriByAction(HttpContext, nameof(GetMovie), values: new { id }) ?? string.Empty;
            return new LinkDTO(url, SelfRel, GetMethod);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete([FromQuery(Name = ID_QUERY_PARAM)] int[] ids)
        {
            var removingResult = await _dataService.RemoveRange(new HashSet<int>(ids));
            if (removingResult == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
