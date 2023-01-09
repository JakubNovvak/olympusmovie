using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieService.ApiModel.Common;
using MovieService.ApiModel.Genres;
using MovieService.Service.Genres;

namespace MovieService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private const string ID_QUERY_PARAM = "id";
        private const string GetMethod = "GET";
        private const string SelfRel = "self";
        private readonly IGenreDataService _dataService;
        private readonly LinkGenerator _linkGenerator;

        public GenreController(IGenreDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GenreDTO>> GetGenre(int id)
        {
            var genre = await _dataService.GetById(id);
            if (genre == null)
            {
                return NotFound();
            }
            return Ok(_dataService.GetById(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<GenreDTO>> GetGenres()
        {
            return Ok(_dataService.GetAll().Select(id => GetLinkToGenre(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Create(GenreDTO genreDTO)
        {
            var id = await _dataService.AddAsync(genreDTO);
            var url = GetLinkToGenre(id);
            return Created(url.Href, url);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(GenreDTO genreDTO)
        {
            var id = await _dataService.EditAsync(genreDTO);
            var url = GetLinkToGenre(id);
            return Ok(url);
        }

        private LinkDTO GetLinkToGenre(int id)
        {
            var url = _linkGenerator.GetUriByAction(HttpContext, nameof(GetGenre), values: new { id }) ?? string.Empty;
            return new LinkDTO(url, SelfRel, GetMethod);
        }

        [HttpDelete]
        //[Authorize(Roles = "Administrator")]
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
