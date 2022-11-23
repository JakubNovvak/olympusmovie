using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieService.ApiModel;
using MovieService.Service;

namespace MovieService.Controller
{
    [Route(RESOURCE_PATH)]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private const string RESOURCE_PATH = "api/series";
        private const string ID_QUERY_PARAM = "id";
        private const string GetMethod = "GET";
        private const string SelfRel = "self";
        private readonly ISeriesDataService _dataService;
        private readonly LinkGenerator _linkGenerator;

        public SeriesController(ISeriesDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SeriesDTO>> GetOneSeries(int id)
        {
            var series = await _dataService.GetById(id);
            if (series == null)
            {
                return NotFound();
            }
            return Ok(_dataService.GetById(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<SeriesDTO>> GetSeries()
        {
            return Ok(_dataService.GetAll().Select(id => GetLinkToOneSeries(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Create(SeriesDTO seriesDTO)
        {
            var id = await _dataService.AddAsync(seriesDTO);
            var url = GetLinkToOneSeries(id);
            return Created(url.Href, url);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(SeriesDTO seriesDTO)
        {
            var id = await _dataService.EditAsync(seriesDTO);
            var url = GetLinkToOneSeries(id);
            return Ok(url);
        }

        private LinkDTO GetLinkToOneSeries(int id)
        {
            var url = _linkGenerator.GetUriByAction(HttpContext, nameof(GetOneSeries), values: new { id }) ?? string.Empty;
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
