using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.ApiModel;
using UserService.Infrastructure;
using UserService.Service;

namespace UserService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private const string USER_ID = "userId";
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

        [HttpGet("{userId:int}")]
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
        public async Task<ActionResult> Delete([FromQuery(Name = USER_ID)] int userId)
        {
            var removingResult = await _dataService.Remove(userId);
            if (removingResult == false)
            {
                return NotFound();
            }
            return NoContent();
        }


        [HttpGet("{userId:int}/Movies/PlannedToWatch")]
        public ActionResult GetMoviesPlannedToWatch(int userId)
        {
            if (!_dataService.UserExists(userId))
            {
                return NotFound();
            }
            return Ok(_dataService.GetUserMovies(userId, RelationTypeConstants.WATCHED));
        }
        
        [HttpPost("{userId:int}/Movies/PlannedToWatch")]
        public async Task<ActionResult> AddMoviesPlannedToWatch(int userId, [FromQuery(Name = MOVIE_ID_QUERY_PARAM)] int[] movieIds)
        {
            if (!_dataService.UserExists(userId))
            {
                return NotFound();
            }
            await _dataService.AddUserToMovieRelations(userId, new List<int>(movieIds), RelationTypeConstants.WATCHED);
            return NoContent();
        }

        [HttpGet("{userId:int}/Movies/Watched")]
        public ActionResult GetMoviesWatched(int userId)
        {
            if (!_dataService.UserExists(userId))
            {
                return NotFound();
            }
            return Ok(_dataService.GetUserMovies(userId, RelationTypeConstants.WATCHED));
        }

        [HttpPost("{userId:int}/Movies/Watched")]
        public async Task<ActionResult> AddMoviesWatched(int userId, [FromQuery(Name = MOVIE_ID_QUERY_PARAM)] int movieIds)
        {
            if (!_dataService.UserExists(userId))
            {
                return NotFound();
            }
            await _dataService.AddUserToMovieRelations(userId, new List<int>(movieIds), RelationTypeConstants.WATCHED);
            return NoContent();
        }
    }
}
