using Microsoft.AspNetCore.Mvc;
using UserService.Infrastructure;
using UserService.Model.Relations;
using UserService.Service;

namespace UserService.Controller
{
    [Route("api/User")]
    [ApiController]
    public class UserMoviesController : ControllerBase
    {
        private const string PRODUCTION_ID_QUERY_PARAM = "productionId";

        private readonly IUserDataService _dataService;
        
        public UserMoviesController(IUserDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("{userId:int}/Movies/PlanToWatch")]
        public ActionResult GetMoviesPlannedToWatch(int userId)
        {
            return Get(userId, RelationTypeConstants.PLAN_TO_WATCH);
        }

        [HttpPost("{userId:int}/Movies/PlanToWatch/Sync")]
        public async Task<ActionResult> SyncMoviesPlannedToWatch(int userId, [FromQuery(Name = PRODUCTION_ID_QUERY_PARAM)] int[] movieIds)
        {
            return await Sync(userId, movieIds, RelationTypeConstants.PLAN_TO_WATCH);
        }

        [HttpGet("{userId:int}/Movies/Watched")]
        public ActionResult GetMoviesWatched(int userId)
        {
            return Get(userId, RelationTypeConstants.WATCHED);
        }

        [HttpPost("{userId:int}/Movies/Watched/Sync")]
        public async Task<ActionResult> SyncMoviesWatched(int userId, [FromQuery(Name = PRODUCTION_ID_QUERY_PARAM)] int[] movieIds)
        {
            return await Sync(userId, movieIds, RelationTypeConstants.WATCHED);
        }

        [HttpGet("{userId:int}/Movies/OnHold")]
        public ActionResult GetMoviesOnHold(int userId)
        {
            return Get(userId, RelationTypeConstants.ON_HOLD);
        }

        [HttpPost("{userId:int}/Movies/OnHold/Sync")]
        public async Task<ActionResult> SyncMoviesOnHold(int userId, [FromQuery(Name = PRODUCTION_ID_QUERY_PARAM)] int[] movieIds)
        {
            return await Sync(userId, movieIds, RelationTypeConstants.ON_HOLD);
        }

        [HttpGet("{userId:int}/Movies/Dropped")]
        public ActionResult GetMoviesDropped(int userId)
        {
            return Get(userId, RelationTypeConstants.DROPPED);
        }

        [HttpPost("{userId:int}/Movies/Dropped/Sync")]
        public async Task<ActionResult> SyncMoviesDropped(int userId, [FromQuery(Name = PRODUCTION_ID_QUERY_PARAM)] int[] movieIds)
        {
            return await Sync(userId, movieIds, RelationTypeConstants.DROPPED);
        }

        [HttpGet("{userId:int}/Movies/Favorite")]
        public ActionResult GetMoviesFavorite(int userId)
        {
            return Get(userId, RelationTypeConstants.FAVORITE);
        }


        [HttpPost("{userId:int}/Movies/Favorite/Sync")]
        public async Task<ActionResult> SyncMoviesFavorite(int userId, [FromQuery(Name = PRODUCTION_ID_QUERY_PARAM)] int[] movieIds)
        {
            return await Sync(userId, movieIds, RelationTypeConstants.FAVORITE);
        }

        private async Task<ActionResult> Sync(int userId, int[] objectIds, string typeOfRelation)
        {
            if (!_dataService.UserExists(userId))
            {
                return NotFound();
            }
            return Ok(await _dataService.SyncUserToObjectRelations(userId, new HashSet<int>(objectIds), typeOfRelation, PositionTypeConstants.MOVIE));
        }

        private ActionResult Get(int userId, string relationType)
        {
            if (!_dataService.UserExists(userId))
            {
                return NotFound();
            }
            return Ok(_dataService.GetUserRelatedObjectIds(userId, relationType, PositionTypeConstants.MOVIE));
        }
    }
}
