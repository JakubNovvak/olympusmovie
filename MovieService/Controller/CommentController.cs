using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieService.ApiModel;
using MovieService.Service;

namespace MovieService.Controller
{
    [Route(RESOURCE_PATH)]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private const string RESOURCE_PATH = "api/comments";
        private const string ID_QUERY_PARAM = "id";
        private const string GetMethod = "GET";
        private const string SelfRel = "self";
        private readonly ICommentDataService _dataService;
        private readonly LinkGenerator _linkGenerator;

        public CommentController(ICommentDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CommentDTO>> GetComment(int id)
        {
            var comment = await _dataService.GetById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(_dataService.GetById(id));
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommentDTO>> GetComments()
        {
            return Ok(_dataService.GetAll().Select(id => GetLinkToComment(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Create(CommentDTO commentDTO)
        {
            var id = await _dataService.AddAsync(commentDTO);
            var url = GetLinkToComment(id);
            return Created(url.Href, url);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(CommentDTO commentDTO)
        {
            var id = await _dataService.EditAsync(commentDTO);
            var url = GetLinkToComment(id);
            return Ok(url);
        }

        private LinkDTO GetLinkToComment(int id)
        {
            var url = _linkGenerator.GetUriByAction(HttpContext, nameof(GetComment), values: new { id }) ?? string.Empty;
            return new LinkDTO(url, SelfRel, GetMethod);
        }

        [HttpDelete]
        //[Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete([FromQuery(Name = ID_QUERY_PARAM)] int id)
        {
            var removingResult = await _dataService.Remove(id);
            if (removingResult == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
