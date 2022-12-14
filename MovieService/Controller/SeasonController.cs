using Microsoft.AspNetCore.Mvc;
using MovieService.ApiModel.Common;
using MovieService.ApiModel.Movies;
using MovieService.ApiModel.Seasons;
using MovieService.Service.Seasons;

namespace MovieService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        private const string ID_QUERY_PARAM = "id";
        private const string TITLE_QUERY_PARAM = "title";
        private const string GET = "GET";
        private const string SELF = "self";
        
        private readonly ISeasonDataService _dataService;
        private readonly LinkGenerator _linkGenerator;

        public SeasonController(ISeasonDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SeasonDetailsDTO>> GetSeason(int id)
        {
            var season = await _dataService.GetById(id);
            if (season == null)
            {
                return NotFound();
            }
            return Ok(season);
        }

        [HttpGet("{id:int}/EditVersion")]
        public async Task<ActionResult<SeasonCreateEditDTO>> GetEditSeason(int id)
        {
            var season = await _dataService.GetEditVersionById(id);
            if (season == null)
            {
                return NotFound();
            }
            return Ok(season);
        }

        [HttpGet]
        public ActionResult<IEnumerable<SeasonDTO>> GetSeasons([FromQuery(Name = TITLE_QUERY_PARAM)] string? title)
        {
            IEnumerable<SeasonDTO> seasons = _dataService.GetAll();
            if (string.IsNullOrEmpty(title))
            {
                return Ok(seasons);
            }
            return Ok(seasons.Where(season => season.Title.ToLower().Contains(title.ToLower())));
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<ActionResult> Create(SeasonCreateEditDTO seasonDTO)
        {
            var id = await _dataService.AddAsync(seasonDTO);
            var url = GetLinkToSeason(id);
            return Created(url.Href, url);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(SeasonCreateEditDTO seasonDTO)
        {
            var id = await _dataService.EditAsync(seasonDTO);
            var url = GetLinkToSeason(id);
            return Ok(url);
        }

        private LinkDTO GetLinkToSeason(int id)
        {
            var url = _linkGenerator.GetUriByAction(HttpContext, nameof(GetSeason), values: new { id }) ?? string.Empty;
            return new LinkDTO(url, SELF, GET);
        }

        [HttpDelete]
        //[Authorize(Roles = "Admin")]
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
