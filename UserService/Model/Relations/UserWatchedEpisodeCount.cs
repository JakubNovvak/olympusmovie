namespace UserService.Model.Relations
{
    public class UserWatchedEpisodesCount
    {
        public int UserId { get; set; }
        public int SeasonId { get; set; }
        public int WatchedCount { get; set; }
    }
}
