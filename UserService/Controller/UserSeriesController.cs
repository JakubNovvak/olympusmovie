using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Infrastructure;
using UserService.Model.Relations;
using UserService.Service;

namespace UserService.Controller
{
    /// <summary>
    /// Test
    /// </summary>
    [Route("api/User")]
    [ApiController]
    public class UserSeriesController : ControllerBase
    {
        private readonly IUserDataService _dataService;

        public UserSeriesController(IUserDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("{userId:int}/Series/PlanToWatch")]
        public ActionResult GetSeriesPlannedToWatch(int userId)
        {
            return Get<UserToSeriesRelation>(userId, RelationTypeConstants.PLAN_TO_WATCH);
        }

        [HttpPost("{userId:int}/Series/PlanToWatch/Sync")]
        public async Task<ActionResult> SyncSeriesPlannedToWatch(int userId, [FromQuery(Name = Constants.PRODUCTION_ID_QUERY_PARAM)] int[] seriesIds)
        {
            return await Sync<UserToSeriesRelation>(userId, seriesIds, RelationTypeConstants.PLAN_TO_WATCH);
        }

        [HttpGet("{userId:int}/Series/Watched")]
        public ActionResult GetSeriesWatched(int userId)
        {
            return Get<UserToSeriesRelation>(userId, RelationTypeConstants.WATCHED);
        }

        [HttpPost("{userId:int}/Series/Watched/Sync")]
        public async Task<ActionResult> SyncSeriesWatched(int userId, [FromQuery(Name = Constants.PRODUCTION_ID_QUERY_PARAM)] int[] seriesIds)
        {
            return await Sync<UserToSeriesRelation>(userId, seriesIds, RelationTypeConstants.WATCHED);
        }

        [HttpGet("{userId:int}/Series/OnHold")]
        public ActionResult GetSeriesOnHold(int userId)
        {
            return Get<UserToSeriesRelation>(userId, RelationTypeConstants.ON_HOLD);
        }

        [HttpPost("{userId:int}/Series/OnHold/Sync")]
        public async Task<ActionResult> SyncSeriesOnHold(int userId, [FromQuery(Name = Constants.PRODUCTION_ID_QUERY_PARAM)] int[] seriesIds)
        {
            return await Sync<UserToSeriesRelation>(userId, seriesIds, RelationTypeConstants.ON_HOLD);
        }

        [HttpGet("{userId:int}/Series/Dropped")]
        public ActionResult GetSeriesDropped(int userId)
        {
            return Get<UserToSeriesRelation>(userId, RelationTypeConstants.DROPPED);
        }

        [HttpPost("{userId:int}/Series/Dropped/Sync")]
        public async Task<ActionResult> SyncSeriesDropped(int userId, [FromQuery(Name = Constants.PRODUCTION_ID_QUERY_PARAM)] int[] seriesIds)
        {
            return await Sync<UserToSeriesRelation>(userId, seriesIds, RelationTypeConstants.DROPPED);
        }

        [HttpGet("{userId:int}/Series/Favorite")]
        public ActionResult GetSeriesFavorite(int userId)
        {
            return Get<UserToSeriesRelation>(userId, RelationTypeConstants.FAVORITE);
        }


        [HttpPost("{userId:int}/Series/Favorite/Sync")]
        public async Task<ActionResult> SyncSeriesFavorite(int userId, [FromQuery(Name = Constants.PRODUCTION_ID_QUERY_PARAM)] int[] seriesIds)
        {
            return await Sync<UserToSeriesRelation>(userId, seriesIds, RelationTypeConstants.FAVORITE);
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
