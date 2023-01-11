using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserService.ApiModel;
using UserService.Infrastructure;
using UserService.Model.Relations;
using UserService.Service;

namespace UserService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private const string GetMethod = "GET";
        private const string SelfRel = "self";
        private const string USER_ID = "userId";
        private const string USER_NAME = "username";

        private readonly IUserDataService _dataService;
        private readonly LinkGenerator _linkGenerator;

        public UserController(IUserDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{userId:int}")]
        public async Task<ActionResult<UserDTO>> GetUser(int userId)
        {
            var user = await _dataService.GetById(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetUserByUsername([FromQuery(Name = USER_NAME)] string username)
        {
            var user = await _dataService.GetByUsername(username);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserDTO userDTO)
        {
            var id = await _dataService.AddAsync(userDTO);
            var url = GetLinkToUser(id);
            return Created(url.Href, url);
        }

        [HttpPut]
        public async Task<ActionResult> EditPersonalData(UserDTO userDTO)
        {
            var id = await _dataService.ChangeAccountData(userDTO);
            var url = GetLinkToUser(id);
            return Ok(url);
        }

        private LinkDTO GetLinkToUser(int id)
        {
            var url = _linkGenerator.GetUriByAction(HttpContext, nameof(GetUser), values: new { id }) ?? string.Empty;
            return new LinkDTO(url, SelfRel, GetMethod);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery(Name = USER_ID)] int userId)
        {
            var removingResult = await _dataService.Remove(userId);
            if (removingResult == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
