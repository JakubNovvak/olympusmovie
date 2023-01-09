using Microsoft.AspNetCore.Mvc;
using MovieService.ApiModel.Common;
using MovieService.ApiModel.Persons;
using MovieService.Model;
using MovieService.Service.Persons;

namespace MovieService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private const string ID_QUERY_PARAM = "id";
        private const string GetMethod = "GET";
        private const string SelfRel = "self";
        private readonly IPersonDataService _dataService;
        private readonly LinkGenerator _linkGenerator;

        public PersonController(IPersonDataService dataService, LinkGenerator linkGenerator)
        {
            _dataService = dataService;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PersonDTO>> GetPerson(int id)
        {
            var person = await _dataService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetPersons()
        {
            return Ok(_dataService.GetAll().Select(id => GetLinkToPerson(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Create(PersonDTO personDTO)
        {
            var id = await _dataService.AddAsync(personDTO);
            var url = GetLinkToPerson(id);
            return Ok(url);
        }

        [HttpPut]
        public async Task<ActionResult> Edit(PersonDTO personDTO)
        {
            var id = await _dataService.EditAsync(personDTO);
            var url = GetLinkToPerson(id);
            return Ok(url);
        }

        private LinkDTO GetLinkToPerson(int id)
        {
            var url = _linkGenerator.GetUriByAction(HttpContext, nameof(GetPerson), values: new { id }) ?? string.Empty;
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
