using Microsoft.AspNetCore.Mvc;
using MovieService.ApiModel.Common;
using MovieService.ApiModel.Reviews;
using MovieService.Infrastructure;
using MovieService.Model;
using MovieService.Service.Reviews;

namespace MovieService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private const string ID_QUERY_PARAM = "id";
        private const string TITLE_QUERY_PARAM = "title";
        private const string POSITION_ID_QUERY_PARAM = "positionId";
        private const string POSITION_TYPE_QUERY_PARAM = "positionType";
        private const string GetMethod = "GET";
        private const string SelfRel = "self";
        private readonly IReviewDataService _dataService;
        private readonly LinkGenerator _linkGenerator;

        public ReviewController(IReviewDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReviewDTO>> GetReview(int id)
        {
            var review = await _dataService.GetById(id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        [HttpGet]
        public ActionResult<IEnumerable<ReviewDTO>> GetReviews([FromQuery(Name = POSITION_ID_QUERY_PARAM)] int? positionId,
            [FromQuery(Name = POSITION_TYPE_QUERY_PARAM)] string? positionType)
        {
            if (positionId != null && positionType == null)
            {
                return BadRequest("Position type is required when position id is provided");
            }
            return _dataService.GetAll(GetProperPredicateForGettingReviews(positionId, positionType)).ToList();
        }

        private static Func<Review, bool> GetProperPredicateForGettingReviews(int? positionId, string? positionType)
        {
            Func<Review, bool> predicate = review => true;
            if (positionType != null)
            {
                if (positionId != null)
                {
                    predicate = review => positionType switch
                    {
                        PositionTypeConstants.MOVIE => review.Rating.MovieId == positionId,
                        PositionTypeConstants.SEASON => review.Rating.SeasonId == positionId,
                        _ => false
                    };
                }
                else
                {
                    predicate = review => positionType switch
                    {
                        PositionTypeConstants.MOVIE => review.Rating.MovieId != null,
                        PositionTypeConstants.SEASON => review.Rating.SeasonId != null,
                        _ => false
                    };
                }
            }

            return predicate;
        }

        [HttpPost]
        public async Task<ActionResult> Create(ReviewDTO reviewDTO)
        {
            var id = await _dataService.AddAsync(reviewDTO);
            var url = GetLinkToReview(id);
            return Created(url.Href, url);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(ReviewDTO reviewDTO)
        {
            var id = await _dataService.EditAsync(reviewDTO);
            var url = GetLinkToReview(id);
            return Ok(url);
        }

        private LinkDTO GetLinkToReview(int id)
        {
            var url = _linkGenerator.GetUriByAction(HttpContext, nameof(GetReview), values: new { id }) ?? string.Empty;
            return new LinkDTO(url, SelfRel, GetMethod);
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
