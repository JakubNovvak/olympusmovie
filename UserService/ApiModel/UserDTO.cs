namespace UserService.ApiModel
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Photo { get; set; }
        public string? BackgroundPhoto { get; set; }
        public DateTime? JoinDate { get; set; }
    }
}
