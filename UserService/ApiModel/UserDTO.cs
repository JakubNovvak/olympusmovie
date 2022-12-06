namespace UserService.ApiModel
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string NickName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Photo { get; set; } = null!;
        //public ICollection<int> WatchingMovies { get; set; } = null!;
        //public ICollection<int> CompletedMovies { get; set; } = null!;
        //public ICollection<int> OnHoldMovies { get; set; } = null!;
        //public ICollection<int> DroppedMovies { get; set; } = null!;
        //public ICollection<int> PlanToWatchMovies { get; set; } = null!;
        //public ICollection<int> WatchingSeries { get; set; } = null!;
        //public ICollection<int> CompletedSeries { get; set; } = null!;
        //public ICollection<int> OnHoldSeries { get; set; } = null!;
        //public ICollection<int> DroppedSeries { get; set; } = null!;
        //public ICollection<int> PlanToWatchSeries { get; set; } = null!;
    }
}
