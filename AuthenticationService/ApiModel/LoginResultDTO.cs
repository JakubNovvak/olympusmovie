namespace AuthenticationService.ApiModel
{
    public class LoginResultDTO
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
