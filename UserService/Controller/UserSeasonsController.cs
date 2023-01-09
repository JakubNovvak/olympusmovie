using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Infrastructure;
using UserService.Model.Relations;
using UserService.Service;

namespace UserService.Controller
{
    [Route("api/User")]
    [ApiController]
    public class UserSeasonsController : ControllerBase
    {
        private const string PRODUCTION_ID_QUERY_PARAM = "productionId";
        private const string EPISODE_COUNT_QUERY_PARAM = "episodeCount";

        private readonly IUserDataService _dataService;

        public UserSeasonsController(IUserDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("{userId:int}/Seasons/PlanToWatch")]
        public ActionResult GetSeasonsPlannedToWatch(int userId)
        {
            return Get(userId, RelationTypeConstants.PLAN_TO_WATCH);
        }

        [HttpPost("{userId:int}/Seasons/PlanToWatch/Sync")]
        public async Task<ActionResult> SyncSeasonsPlannedToWatch(int userId, [FromQuery(Name = PRODUCTION_ID_QUERY_PARAM)] int[] seasonIds)
        {
            return await Sync(userId, seasonIds, RelationTypeConstants.PLAN_TO_WATCH);
        }

        [HttpGet("{userId:int}/Seasons/Watched")]
        public ActionResult GetSeasonsWatched(int userId)
        {
            return Get(userId, RelationTypeConstants.WATCHED);
        }

        [HttpPost("{userId:int}/Seasons/Watched/Sync")]
        public async Task<ActionResult> SyncSeasonsWatched(int userId, [FromQuery(Name = PRODUCTION_ID_QUERY_PARAM)] int[] seasonIds)
        {
            return await Sync(userId, seasonIds, RelationTypeConstants.WATCHED);
        }

        [HttpGet("{userId:int}/Seasons/OnHold")]
        public ActionResult GetSeasonsOnHold(int userId)
        {
            return Get(userId, RelationTypeConstants.ON_HOLD);
        }

        [HttpPost("{userId:int}/Seasons/OnHold/Sync")]
        public async Task<ActionResult> SyncSeasonsOnHold(int userId, [FromQuery(Name = PRODUCTION_ID_QUERY_PARAM)] int[] seasonIds)
        {
            return await Sync(userId, seasonIds, RelationTypeConstants.ON_HOLD);
        }

        [HttpGet("{userId:int}/Seasons/Dropped")]
        public ActionResult GetSeasonsDropped(int userId)
        {
            return Get(userId, RelationTypeConstants.DROPPED);
        }

        [HttpPost("{userId:int}/Seasons/Dropped/Sync")]
        public async Task<ActionResult> SyncSeasonsDropped(int userId, [FromQuery(Name = PRODUCTION_ID_QUERY_PARAM)] int[] seasonsIds)
        {
            return await Sync(userId, seasonsIds, RelationTypeConstants.DROPPED);
        }

        [HttpGet("{userId:int}/Seasons/Favorite")]
        public ActionResult GetSeasonsFavorite(int userId)
        {
            return Get(userId, RelationTypeConstants.FAVORITE);
        }


        [HttpPost("{userId:int}/Seasons/Favorite/Sync")]
        public async Task<ActionResult> SyncSeasonsFavorite(int userId, [FromQuery(Name = PRODUCTION_ID_QUERY_PARAM)] int[] seasonsIds)
        {
            return await Sync(userId, seasonsIds, RelationTypeConstants.FAVORITE);
        }

        [HttpPost("{userId:int}/Seasons/WatchedEpisodesCount/Sync")]
        public async Task<ActionResult> SyncEpisodeCount(int userId,
            [FromQuery(Name = PRODUCTION_ID_QUERY_PARAM)] int[] seasonsIds,
            [FromQuery(Name = EPISODE_COUNT_QUERY_PARAM)] int episodeCount)
        {
            await _dataService.SyncEpisodeCount(userId, seasonsIds, episodeCount);
            return NoContent();
        }

        [HttpPost("{userId:int}/Seasons/{seasonId:int}/WatchedEpisodesCount")]
        public ActionResult GetEpisodeCount(int userId, int seasonId)
        {
            return Ok(_dataService.GetEpisodeCount(userId, seasonId));
        }

        private async Task<ActionResult> Sync(int userId, int[] objectIds, string typeOfRelation)
        {
            if (!_dataService.UserExists(userId))
            {
                return NotFound();
            }
            return Ok(await _dataService.SyncUserToObjectRelations(userId, new HashSet<int>(objectIds), typeOfRelation, PositionTypeConstants.SEASON));
        }

        private ActionResult Get(int userId, string relationType)
        {
            if (!_dataService.UserExists(userId))
            {
                return NotFound();
            }
            return Ok(_dataService
                .GetUserRelatedObjectIds(userId, relationType, PositionTypeConstants.SEASON));
        }
    }
}
