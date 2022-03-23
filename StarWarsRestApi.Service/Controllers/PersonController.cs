using Microsoft.AspNetCore.Mvc;
using StarWarsRestApi.Service.Data;
using StarWarsRestApi.Service.Models;

namespace StarWarsRestApi.Service.Controllers
{
    /// <summary>
    /// The API Controller for the /api/person endpoint.
    /// </summary>
    [Route("api/person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DataModel datamodel;

        public PersonController(DataModel datamodel)
        {
            this.datamodel = datamodel;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesDefaultResponseType(typeof(IEnumerable<Person>))]
        public IEnumerable<Person> Get()
        {
            return datamodel.People.Values;
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(Person))]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            if (datamodel.People.ContainsKey(id))
            {
                return Ok(datamodel.People[id]);
            }
            return NotFound();
        }
    }
}
