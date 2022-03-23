using Microsoft.AspNetCore.Mvc;
using StarWarsRestApi.Service.Data;
using StarWarsRestApi.Service.Models;

namespace StarWarsRestApi.Service.Controllers
{
    /// <summary>
    /// The API Controller for the /api/vehicle endpoint.
    /// </summary>
    [Route("api/vehicle")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly DataModel datamodel;

        public VehicleController(DataModel datamodel)
        {
            this.datamodel = datamodel;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesDefaultResponseType(typeof(IEnumerable<Vehicle>))]
        public IEnumerable<Vehicle> Get()
        {
            return datamodel.Vehicles.Values;
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(Vehicle))]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            if (datamodel.Vehicles.ContainsKey(id))
            {
                return Ok(datamodel.Vehicles[id]);
            }
            return NotFound();
        }
    }
}
