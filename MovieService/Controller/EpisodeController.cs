using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieService.ApiModel;
using MovieService.Service;

namespace MovieService.Controller
{
    [Route(RESOURCE_PATH)]
    [ApiController]
    public class EpisodeController : ControllerBase
    {
        private const string RESOURCE_PATH = "api/episodes";
        private const string ID_QUERY_PARAM = "id";
        private const string GetMethod = "GET";
        private const string SelfRel = "self";
        private readonly IEpisodeDataService _dataService;
        private readonly LinkGenerator _linkGenerator;

        public EpisodeController(IEpisodeDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EpisodeDTO>> GetEpisode(int id)
        {
            var episode = await _dataService.GetById(id);
            if (episode == null)
            {
                return NotFound();
            }
            return Ok(_dataService.GetById(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<EpisodeDTO>> GetEpisodes()
        {
            return Ok(_dataService.GetAll().Select(id => GetLinkToEpisode(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Create(EpisodeDTO episodeDTO)
        {
            var id = await _dataService.AddAsync(episodeDTO);
            var url = GetLinkToEpisode(id);
            return Created(url.Href, url);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(EpisodeDTO episodeDTO)
        {
            var id = await _dataService.EditAsync(episodeDTO);
            var url = GetLinkToEpisode(id);
            return Ok(url);
        }

        private LinkDTO GetLinkToEpisode(int id)
        {
            var url = _linkGenerator.GetUriByAction(HttpContext, nameof(GetEpisode), values: new { id }) ?? string.Empty;
            return new LinkDTO(url, SelfRel, GetMethod);
        }

        [HttpDelete]
        [Authorize(Roles = "Administrator")]
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
