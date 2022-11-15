namespace JwtAuthenticationManager.Model
{
    public class UserAccount
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!; 
    }
}
