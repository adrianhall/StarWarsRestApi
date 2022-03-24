using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using StarWarsRestApi.Service.Data;
using StarWarsRestApi.Service.Models;
using StarWarsRestApi.Service.Serialization;

namespace StarWarsRestApi.Service.Controllers
{
    /// <summary>
    /// The API Controller for the /api/starship endpoint.
    /// </summary>
    [Route("api/starship")]
    [ApiController]
    public class StarshipController : ControllerBase
    {
        private readonly DataModel datamodel;

        public StarshipController(DataModel datamodel, IServer server)
        {
            AppUriHelper.Initialize(server);
            this.datamodel = datamodel;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesDefaultResponseType(typeof(IEnumerable<Starship>))]
        public IEnumerable<Starship> Get()
        {
            return datamodel.Starships.Values;
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(Starship))]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            if (datamodel.Starships.ContainsKey(id))
            {
                return Ok(datamodel.Starships[id]);
            }
            return NotFound();
        }
    }
}
