﻿namespace AuthenticationService.ApiModel
{
    public class RefreshTokenDTO
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
