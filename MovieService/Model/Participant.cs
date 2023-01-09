namespace MovieService.Model
{
    public class Participant
    {        
        public int? MovieId { get; set; }
        public virtual Movie? Movie { get; set; }
        public int? SeasonId { get; set; }
        public virtual Season? Season { get; set; }
        
        public int PersonId { get; set; }
        public virtual Person Person { get; set; } = null!;
        public int RoleId { get; set; }
        public virtual Role Role { get; set; } = null!;
    }
}
