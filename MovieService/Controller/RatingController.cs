using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieService.ApiModel.Common;
using MovieService.ApiModel.Ratings;
using MovieService.Service.Ratings;

namespace MovieService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private const string ID_QUERY_PARAM = "id";
        private const string TITLE_QUERY_PARAM = "title";
        private const string GetMethod = "GET";
        private const string SelfRel = "self";
        private readonly IRatingDataService _dataService;
        private readonly LinkGenerator _linkGenerator;

        public RatingController(IRatingDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RatingDTO>> GetRating(int id)
        {
            var rating = await _dataService.GetById(id);
            if (rating == null)
            {
                return NotFound();
            }
            return Ok(rating);
        }

        [HttpPost]
        public async Task<ActionResult> Create(RatingDTO ratingDTO)
        {
            var id = await _dataService.AddAsync(ratingDTO);
            var url = GetLinkToRating(id);
            return Created(url.Href, url);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(RatingDTO ratingDTO)
        {
            var id = await _dataService.EditAsync(ratingDTO);
            var url = GetLinkToRating(id);
            return Ok(url);
        }

        private LinkDTO GetLinkToRating(int id)
        {
            var url = _linkGenerator.GetUriByAction(HttpContext, nameof(GetRating), values: new { id }) ?? string.Empty;
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
