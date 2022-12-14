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

        private readonly IUserDataService _dataService;

        public UserSeasonsController(IUserDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("{userId:int}/Seasons/PlanToWatch")]
        public ActionResult GetSeasonsPlannedToWatch(int userId)
        {
            return Get<UserToSeasonRelation>(userId, RelationTypeConstants.PLAN_TO_WATCH);
        }

        [HttpPost("{userId:int}/Seasons/PlanToWatch/Sync")]
        public async Task<ActionResult> SyncSeasonsPlannedToWatch(int userId, [FromQuery(Name = Constants.PRODUCTION_ID_QUERY_PARAM)] int[] seasonIds)
        {
            return await Sync<UserToSeasonRelation>(userId, seasonIds, RelationTypeConstants.PLAN_TO_WATCH);
        }

        [HttpGet("{userId:int}/Seasons/Watched")]
        public ActionResult GetSeasonsWatched(int userId)
        {
            return Get<UserToSeasonRelation>(userId, RelationTypeConstants.WATCHED);
        }

        [HttpPost("{userId:int}/Seasons/Watched/Sync")]
        public async Task<ActionResult> SyncSeasonsWatched(int userId, [FromQuery(Name = Constants.PRODUCTION_ID_QUERY_PARAM)] int[] seasonIds)
        {
            return await Sync<UserToSeasonRelation>(userId, seasonIds, RelationTypeConstants.WATCHED);
        }

        [HttpGet("{userId:int}/Seasons/OnHold")]
        public ActionResult GetSeasonsOnHold(int userId)
        {
            return Get<UserToSeasonRelation>(userId, RelationTypeConstants.ON_HOLD);
        }

        [HttpPost("{userId:int}/Seasons/OnHold/Sync")]
        public async Task<ActionResult> SyncSeasonsOnHold(int userId, [FromQuery(Name = Constants.PRODUCTION_ID_QUERY_PARAM)] int[] seasonIds)
        {
            return await Sync<UserToSeasonRelation>(userId, seasonIds, RelationTypeConstants.ON_HOLD);
        }

        [HttpGet("{userId:int}/Seasons/Dropped")]
        public ActionResult GetSeasonsDropped(int userId)
        {
            return Get<UserToSeasonRelation>(userId, RelationTypeConstants.DROPPED);
        }

        [HttpPost("{userId:int}/Seasons/Dropped/Sync")]
        public async Task<ActionResult> SyncSeasonsDropped(int userId, [FromQuery(Name = Constants.PRODUCTION_ID_QUERY_PARAM)] int[] seasonsIds)
        {
            return await Sync<UserToSeasonRelation>(userId, seasonsIds, RelationTypeConstants.DROPPED);
        }

        [HttpGet("{userId:int}/Seasons/Favorite")]
        public ActionResult GetSeasonsFavorite(int userId)
        {
            return Get<UserToSeasonRelation>(userId, RelationTypeConstants.FAVORITE);
        }


        [HttpPost("{userId:int}/Seasons/Favorite/Sync")]
        public async Task<ActionResult> SyncSeasonsFavorite(int userId, [FromQuery(Name = Constants.PRODUCTION_ID_QUERY_PARAM)] int[] seasonsIds)
        {
            return await Sync<UserToSeasonRelation>(userId, seasonsIds, RelationTypeConstants.FAVORITE);
        }

        private async Task<ActionResult> Sync<TRelation>(int userId, int[] objectIds, string typeOfRelation) where TRelation : Relation, new()
        {
            if (!_dataService.UserExists(userId))
            {
                return NotFound();
            }
            await _dataService
                .SyncUserToObjectRelations<TRelation>(userId, new HashSet<int>(objectIds), typeOfRelation);
            return NoContent();
        }

        private ActionResult Get<TRelation>(int userId, string relationType) where TRelation : Relation
        {
            if (!_dataService.UserExists(userId))
            {
                return NotFound();
            }
            return Ok(_dataService
                .GetUserRelatedObjectIds<TRelation>(userId, relationType));
        }
    }
}
