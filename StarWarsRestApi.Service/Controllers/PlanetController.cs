using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using StarWarsRestApi.Service.Data;
using StarWarsRestApi.Service.Models;
using StarWarsRestApi.Service.Serialization;

namespace StarWarsRestApi.Service.Controllers
{
    /// <summary>
    /// The API Controller for the /api/planet endpoint.
    /// </summary>
    [Route("api/planet")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly DataModel datamodel;

        public PlanetController(DataModel datamodel, IServer server)
        {
            AppUriHelper.Initialize(server);
            this.datamodel = datamodel;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesDefaultResponseType(typeof(IEnumerable<Planet>))]
        public IEnumerable<Planet> Get()
        {
            return datamodel.Planets.Values;
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(Planet))]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            if (datamodel.Planets.ContainsKey(id))
            {
                return Ok(datamodel.Planets[id]);
            }
            return NotFound();
        }
    }
}
