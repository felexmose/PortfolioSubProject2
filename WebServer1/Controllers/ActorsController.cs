using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WebServer1.Models;

namespace WebServer1.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsController : ControllerBase
    {
        private IDataService _dataService;
        private readonly LinkGenerator _generator;
        private const int MaxPageSize = 25;

        public ActorsController(IDataService dataService, LinkGenerator generator)
        {
            _dataService = dataService;
            _generator = generator;
        }

        [HttpGet]
        public IActionResult GetAllActors(int page = 0, int pageSize = 10)
        {
            pageSize = pageSize > MaxPageSize? MaxPageSize : pageSize;

            var actors =
                _dataService.getAllActors(page,pageSize).ToList().Select(x => CreateNameBasicModel(x));

            return Ok(actors);
        }

        [HttpGet("{id}", Name = nameof(GetActor))]
        public IActionResult GetActor(string id)
        {
            var actor =
                _dataService.GetActor(id);
            if (actor == null)
            {
                return NotFound();
            }

            var model = CreateNameBasicModel(actor);

            return Ok(model);
        }

        private NameBasicModel CreateNameBasicModel(NameBasic? actor)
        {
            return new NameBasicModel
            {
                Url = _generator.GetUriByName(HttpContext, nameof(GetActor), new { actor.Id }),
                PrimaryName = actor.PrimaryName,
                BirthYear = actor.BirthYear,
                DeathYear = actor.DeathYear,
                PrimaryProfessions = actor.PrimaryProfessions
            };
        }



    }
}
