using AuthenticationService.ApiModel;

namespace AuthenticationService.Service
{
    public interface IAccountService
    {
        Task<TokensDTO?> Login(LoginDTO loginDTO);
        Task<RefreshTokenDTO> RefreshToken(RefreshTokenDTO refreshTokenDTO);
        Task Register(RegisterDTO registerDTO);
        Task RegisterAdmin(RegisterDTO registerDTO);
        Task Revoke(string username);
        Task RevokeAll();
    }
}