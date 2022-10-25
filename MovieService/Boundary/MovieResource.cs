using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieService.ApiModel;
using MovieService.Control;
using MovieService.Entities;

namespace MovieService.Boundary
{
    [Route(RESOURCE_PATH)]
    [ApiController]
    public class MovieResource : ControllerBase
    {
        private const string RESOURCE_PATH = "api/movies";
        private const string ID_QUERY_PARAM = "id";
        private const string GetMethod = "GET";
        private const string SelfRel = "self";
        private readonly IMovieDataService _dataService;
        private readonly LinkGenerator _linkGenerator;

        public MovieResource(IMovieDataService dataService, LinkGenerator linkGenerator)
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
            return Ok(_dataService.GetById(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieDTO>> GetMovies()
        {
            return Ok(_dataService.GetAll().Select(id => GetLinkToMovie(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Create(MovieDTO movieDTO)
        {
            var movieWrapper = MovieMapper.MapToWrapper(movieDTO);
            var id = await _dataService.AddAsync(movieWrapper);
            var url = GetLinkToMovie(id);
            return Created(url.Href, url);
        }

        private LinkDTO GetLinkToMovie(int id)
        {
            var url = _linkGenerator.GetUriByAction(HttpContext, nameof(GetMovie), values: new { id }) ?? string.Empty;
            return new LinkDTO(url, SelfRel, GetMethod);
        }

        [HttpDelete]
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
