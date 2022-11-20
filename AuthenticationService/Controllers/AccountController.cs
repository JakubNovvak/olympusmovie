using JwtAuthenticationManager;
using JwtAuthenticationManager.ApiModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtTokenHandler _jwtTokenHandler;

        public AccountController(JwtTokenHandler jwtTokenHandler)
        {
            _jwtTokenHandler = jwtTokenHandler;
        }

        [HttpPost]
        public ActionResult<AuthenticationResponseDTO> Authenticate(AuthenticationRequestDTO authenticationRequestDTO)
        {
            var authenticationResponse = _jwtTokenHandler.GenerateJwtToken(authenticationRequestDTO);
            if (authenticationResponse == null)
            {
                return Unauthorized();
            }
            return authenticationResponse;
        }
    }
}
