namespace JwtAuthenticationManager.ApiModel
{
    public class AuthenticationResponseDTO
    {
        public string UserName { get; set; } = null!;
        public string JwtToken { get; set; } = null!;
        public int ExpiresIn { get; set; }
    }
}
