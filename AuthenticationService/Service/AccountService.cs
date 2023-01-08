using AuthenticationService.ApiModel;
using AuthenticationService.Model;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Linq;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using JwtAuthenticationManager;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Service
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AccountService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        public async Task<TokensDTO?> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByNameAsync(loginDTO.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDTO.Password))
            {
                return null;
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            List<Claim> authClaims = GetClaims(user);
            authClaims.AddRange(GetClaimFromUserRole(userRoles));
            var token = CreateToken(authClaims);
            var refreshToken = GenerateRefreshToken();
            _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

            await _userManager.UpdateAsync(user);

            return new TokensDTO()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken,
                Expiration = token.ValidTo
            };
        }

        public async Task Register(RegisterDTO registerDTO)
        {
            var userExists = await _userManager.FindByNameAsync(registerDTO.Username);
            if (userExists != null)
            {
                throw new InvalidOperationException("User already exists!");
            }

            var user = new ApplicationUser()
            {
                Email = registerDTO.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerDTO.Username
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException("User creation failed! Please check user details and try again.");
            }
        }

        public async Task RegisterAdmin(RegisterDTO registerDTO)
        {
            var userExists = await _userManager.FindByNameAsync(registerDTO.Username);
            if (userExists != null)
            {
                throw new InvalidOperationException("User already exists!");
            }

            var user = new ApplicationUser()
            {
                Email = registerDTO.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerDTO.Username
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException("User creation failed! Please check user details and try again.");
            }

            if (await _roleManager.RoleExistsAsync(UserRoles.ADMIN))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.ADMIN));
            }
            if (await _roleManager.RoleExistsAsync(UserRoles.USER))
            {
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.USER));
            }

            await _userManager.AddToRoleAsync(user, UserRoles.ADMIN);
            await _userManager.AddToRoleAsync(user, UserRoles.USER);
        }

        public async Task<RefreshTokenDTO> RefreshToken(RefreshTokenDTO refreshTokenDTO)
        {
            if (refreshTokenDTO == null || refreshTokenDTO.AccessToken == null || refreshTokenDTO.RefreshToken == null)
            {
                throw new InvalidOperationException("Invalid client request");
            }

            string accessToken = refreshTokenDTO.AccessToken;
            string refreshToken = refreshTokenDTO.RefreshToken;

            var principal = GetPrincipalFromExpiredToken(accessToken);
            if (principal == null)
            {
                throw new InvalidOperationException("Invalid access token or refresh token");
            }

            string username = principal.Identity!.Name!;

            var user = await _userManager.FindByNameAsync(username);
            if (user == null || !refreshToken.Equals(user.RefreshToken) || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                throw new InvalidOperationException("Invalid access token or refresh token");
            }

            var newAccessToken = CreateToken(principal.Claims.ToList());
            var newRefreshToken = GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _userManager.UpdateAsync(user);

            return new RefreshTokenDTO()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                RefreshToken = newRefreshToken
            };
        }

        public async Task Revoke(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                throw new InvalidOperationException("Invalid user name");
            }
            user.RefreshToken = null;
            await _userManager.UpdateAsync(user);
        }

        public async Task RevokeAll()
        {
            var users = _userManager.Users.ToList();
            foreach (var user in users)
            {
                user.RefreshToken = null;
                await _userManager.UpdateAsync(user);
            }
        }

        private static IEnumerable<Claim> GetClaimFromUserRole(IList<string> userRoles)
        {
            return from userRole in userRoles
                   select new Claim(ClaimTypes.Role, userRole);
        }

        private static List<Claim> GetClaims(ApplicationUser user)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
        }

        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddSeconds(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (IsSecurityTokenInvalid(securityToken))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;

        }

        private static bool IsSecurityTokenInvalid(SecurityToken securityToken)
        {
            return securityToken is not JwtSecurityToken jwtSecurityToken
                || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
        }

    }
}
