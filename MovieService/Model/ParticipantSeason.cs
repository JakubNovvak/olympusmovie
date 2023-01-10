namespace MovieService.Model
{
    public class ParticipantSeason
    {
        public int SeasonId { get; set; }
        public virtual Season Season { get; set; } = null!;
        public int PersonId { get; set; }
        public virtual Person Person { get; set; } = null!;
        public int RoleId { get; set; }
        public virtual Role Role { get; set; } = null!;
    }
}
