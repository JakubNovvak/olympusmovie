namespace UserService.ApiModel
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Photo { get; set; } = null!;
        public string BackgroundPhoto { get; set; }  = null!;
        public DateTime JoinDate { get; set; }
    }
}
