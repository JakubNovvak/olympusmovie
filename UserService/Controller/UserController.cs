using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.ApiModel;
using UserService.Service;

namespace UserService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private const string ID_QUERY_PARAM = "id";
        private const string MOVIE_ID_QUERY_PARAM = "movieId";
        private const string TITLE_QUERY_PARAM = "title";
        private const string GetMethod = "GET";
        private const string SelfRel = "self";
        private readonly IUserDataService _dataService;
        private readonly LinkGenerator _linkGenerator;

        public UserController(IUserDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDTO>> GetUser(int id)
        {
            var user = await _dataService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserDTO userDTO)
        {
            var id = await _dataService.AddAsync(userDTO);
            var url = GetLinkToUser(id);
            return Created(url.Href, url);
        }

        private LinkDTO GetLinkToUser(int id)
        {
            var url = _linkGenerator.GetUriByAction(HttpContext, nameof(GetUser), values: new { id }) ?? string.Empty;
            return new LinkDTO(url, SelfRel, GetMethod);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery(Name = ID_QUERY_PARAM)] int id)
        {
            var removingResult = await _dataService.Remove(id);
            if (removingResult == false)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("{userId:int}/towatchlist")]
        public async Task<ActionResult> AddMovieToWatch(int userId, [FromQuery(Name = MOVIE_ID_QUERY_PARAM)] int movieId)
        {
            if (!_dataService.UserExists(userId))
            {
                return NotFound();
            }
            await _dataService.AddMoviesPlannedToWatch(userId, movieId);
            return NoContent();
        }

        [HttpGet("{userId:int}/towatchlist")]
        public ActionResult GetMoviesPlannedToWatch(int userId)
        {
            if (!_dataService.UserExists(userId))
            {
                return NotFound();
            }
            return Ok(_dataService.GetMoviesToPlanToWatch(userId));
        }
    }
}
