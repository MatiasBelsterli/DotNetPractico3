using BusinessLayer.IBLs;
using Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase {
        private readonly IBL_Vehiculos _bl;

        public VehiculosController(IBL_Vehiculos bl) {
            _bl = bl;
        }

        // GET: api/vehiculos
        [HttpGet]
        public List<Vehiculo> Get() {
            return _bl.Get();
        }

        // GET api/vehiculos/5543
        [HttpGet("{documento}")]
        public Vehiculo Get(string matricula) {
            
            return _bl.Get(matricula);
        }

        // POST api/vehiculos
        [HttpPost]
        public void Post([FromBody] Vehiculo vehiculo) {
            _bl.Insert(vehiculo);
        }

        // PUT api/vehiculos/5564
        [HttpPut("{id}")]
        public void Put([FromBody] Vehiculo vehiculo) {
            _bl.Update(vehiculo);
        }

        // DELETE api/vehiculos/5453
        [HttpDelete("{id}")]
        public void Delete(string matricula) {
            _bl.Delete(matricula);
        }
    }
}
