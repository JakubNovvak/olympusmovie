namespace UserService.Infrastructure
{
    public class RelationTypeConstants
    {
        public static readonly string PLAN_TO_WATCH = "PlanToWatch";
        public static readonly string WATCHED = "Watched";
        public static readonly string ON_HOLD = "OnHold";
        public static readonly string DROPPED = "Dropped";
        public static readonly string FAVORITE = "Favorite";

        public static List<string> GetAllRelationTypes()
        {
            return new List<string> { PLAN_TO_WATCH, WATCHED, ON_HOLD, DROPPED, FAVORITE };
        }
    }
}
