using Microsoft.AspNetCore.Mvc;
using StarWarsRestApi.Service.Data;
using StarWarsRestApi.Service.Models;

namespace StarWarsRestApi.Service.Controllers
{
    /// <summary>
    /// The API Controller for the /api/species endpoint.
    /// </summary>
    [Route("api/species")]
    [ApiController]
    public class SpeciesController : ControllerBase
    {
        private readonly DataModel datamodel;

        public SpeciesController(DataModel datamodel)
        {
            this.datamodel = datamodel;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesDefaultResponseType(typeof(IEnumerable<Species>))]
        public IEnumerable<Species> Get()
        {
            return datamodel.Species.Values;
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(Species))]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            if (datamodel.Species.ContainsKey(id))
            {
                return Ok(datamodel.Species[id]);
            }
            return NotFound();
        }
    }
}