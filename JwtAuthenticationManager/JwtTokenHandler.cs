using JwtAuthenticationManager.ApiModel;
using JwtAuthenticationManager.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthenticationManager
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "5fd0943f-8fe5-4513-9149-ee8d096f1f13";
        public const int JWT_TOKEN_VALIDITY_MINS = 60;
        private readonly List<UserAccount> _userAccountList;

        public JwtTokenHandler()
        {
            _userAccountList = new List<UserAccount>()
            {
                new UserAccount() { UserName = "admin", Password = "admin", Role = "Administrator" },
                new UserAccount() { UserName = "user", Password = "user", Role = "User" }
            };
        }

        public AuthenticationResponseDTO? GenerateJwtToken(AuthenticationRequestDTO authenticationRequest)
        {
            UserAccount? userAccount = GetUserAccount(authenticationRequest);
            if (userAccount == null)
            {
                return null;
            }

            return new AuthenticationResponseDTO()
            {
                UserName = userAccount.UserName,
                ExpiresIn = JWT_TOKEN_VALIDITY_MINS * 60,
                JwtToken = GetToken(authenticationRequest, userAccount)
            };
        }

        private static string GetToken(AuthenticationRequestDTO authenticationRequest, UserAccount userAccount)
        {
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = GetClaimsIdentity(authenticationRequest, userAccount);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature);
            var securityTokenDescriptor = GetSecurityTokenDescriptor(tokenExpiryTimeStamp, claimsIdentity, signingCredentials);

            var jwtSecurityHandlerToken = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityHandlerToken.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityHandlerToken.WriteToken(securityToken);
            return token;
        }

        private static ClaimsIdentity GetClaimsIdentity(AuthenticationRequestDTO authenticationRequest, UserAccount userAccount)
        {
            return new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, authenticationRequest.UserName!),
                new Claim(ClaimTypes.Role, userAccount.Role)
            });
        }

        private static SecurityTokenDescriptor GetSecurityTokenDescriptor(DateTime tokenExpiryTimeStamp, ClaimsIdentity claimsIdentity, SigningCredentials signingCredentials)
        {
            return new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };
        }

        private UserAccount? GetUserAccount(AuthenticationRequestDTO authenticationRequest)
        {
            if (string.IsNullOrWhiteSpace(authenticationRequest.UserName) || string.IsNullOrWhiteSpace(authenticationRequest.Password))
            {
                return null;
            }

            return _userAccountList
                    .Where(user => user.UserName.Equals(authenticationRequest.UserName) && user.Password.Equals(authenticationRequest.Password))
                    .FirstOrDefault();
        }
    }
}