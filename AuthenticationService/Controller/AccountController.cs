using AuthenticationService;
using AuthenticationService.ApiModel;
using AuthenticationService.Model;
using AuthenticationService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieService.Infrastructure;

namespace ApplicationService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginResultDTO>> Login(LoginDTO loginDTO)
        {
            var loginResult = await _accountService.Login(loginDTO);
            if (loginResult == null)
            {
                return Unauthorized();
            }
            return Ok(loginResult);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            try
            {
                await _accountService.Register(registerDTO);
                return Ok("User registered successfully!");
                
            } catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin(RegisterDTO registerDTO)
        {
            try
            {
                await _accountService.RegisterAdmin(registerDTO);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            return Ok("Admin registered successfully!");
        }

        [HttpPost("RefreshToken")]
        public async Task<ActionResult<RefreshTokenDTO>> RefreshToken(RefreshTokenDTO refreshTokenDTO)
        {
            try
            {
                return await _accountService.RefreshToken(refreshTokenDTO);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize]
        [HttpPost]
        [Route("Revoke/{username}")]
        public async Task<IActionResult> Revoke(string username)
        {
            try
            {
                await _accountService.Revoke(username);
            }
            catch(InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }

            return Ok($"{username} successfully revoked!");
        }

        [Authorize]
        [HttpPost]
        [Route("RevokeAll")]
        public async Task<IActionResult> RevokeAll()
        {
            await _accountService.RevokeAll();
            return Ok("All users successfully revoked!");
        }

        [Authorize]
        [HttpPost]
        [Route("Test")]
        public string Test()
        {
            return "Test OK";
        }
    }
}
