using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using StarWarsRestApi.Service.Data;
using StarWarsRestApi.Service.Models;
using StarWarsRestApi.Service.Serialization;

namespace StarWarsRestApi.Service.Controllers
{
    /// <summary>
    /// The API Controller for the /api/film endpoint.
    /// </summary>
    [Route("api/film")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly DataModel datamodel;

        public FilmController(DataModel datamodel, IServer server)
        {
            AppUriHelper.Initialize(server);
            this.datamodel = datamodel;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesDefaultResponseType(typeof(IEnumerable<Film>))]
        public IEnumerable<Film> Get()
        {
            return datamodel.Films.Values;
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(Film))]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            if (datamodel.Films.ContainsKey(id))
            {
                return Ok(datamodel.Films[id]);
            }
            return NotFound();
        }
    }
}
