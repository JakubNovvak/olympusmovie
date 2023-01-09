using Microsoft.AspNetCore.Mvc;
using MovieService.ApiModel.Common;
using MovieService.ApiModel.Roles;
using MovieService.Service.Roles;

namespace MovieService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private const string ID_QUERY_PARAM = "id";
        private const string GetMethod = "GET";
        private const string SelfRel = "self";
        private readonly IRoleDataService _dataService;
        private readonly LinkGenerator _linkGenerator;

        public RoleController(IRoleDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<RoleDTO>> GetRole(int id)
        {
            var role = await _dataService.GetById(id);
            if(role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpGet]
        public ActionResult<IEnumerable<RoleDTO>> GetRoles()
        {
            return Ok(_dataService.GetAll().Select(id => GetLinkToRole(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Create(RoleDTO roleDTO)
        {
            var id = await _dataService.AddAsync(roleDTO);
            var url = GetLinkToRole(id);
            return Ok(url);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(RoleDTO roleDTO)
        {
            var id = await _dataService.EditAsync(roleDTO);
            var url = GetLinkToRole(id);
            return Ok(url);
        }

        private LinkDTO GetLinkToRole(int id)
        {
            var url = _linkGenerator.GetUriByAction(HttpContext, nameof(GetRole), values: new { id }) ?? string.Empty;
            return new LinkDTO(url, SelfRel, GetMethod);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery(Name = ID_QUERY_PARAM)] int[] ids)
        {
            var removingResult = await _dataService.RemoveRange(new HashSet<int>(ids));
            if (removingResult == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
