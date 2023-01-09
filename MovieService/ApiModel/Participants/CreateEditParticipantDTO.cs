namespace MovieService.ApiModel.Participants
{
    public class CreateEditParticipantDTO
    {
        public int PositionId { get; set; }
        public string PositionType { get; set; }
        public int PersonId { get; set; }
        public int RoleId { get; set; }
    }
}
