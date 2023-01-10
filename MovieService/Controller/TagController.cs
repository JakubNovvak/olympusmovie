using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieService.ApiModel.Common;
using MovieService.ApiModel.Tags;
using MovieService.Service.Tags;

namespace MovieService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private const string ID_QUERY_PARAM = "id";
        private const string GetMethod = "GET";
        private const string SelfRel = "self";
        private readonly ITagDataService _dataService;
        private readonly LinkGenerator _linkGenerator;

        public TagController(ITagDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TagDTO>> GetTag(int id)
        {
            var tag = await _dataService.GetById(id);
            if (tag == null)
            {
                return NotFound();
            }
            return Ok(_dataService.GetById(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<TagDTO>> GetTags()
        {
            return Ok(_dataService.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult> Create(TagDTO tagDTO)
        {
            var id = await _dataService.AddAsync(tagDTO);
            var url = GetLinkToTag(id);
            return Created(url.Href, url);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(TagDTO tagDTO)
        {
            var id = await _dataService.EditAsync(tagDTO);
            var url = GetLinkToTag(id);
            return Ok(url);
        }

        private LinkDTO GetLinkToTag(int id)
        {
            var url = _linkGenerator.GetUriByAction(HttpContext, nameof(GetTag), values: new { id }) ?? string.Empty;
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
