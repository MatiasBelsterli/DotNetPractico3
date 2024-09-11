using BusinessLayer.IBLs;
using Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase {
        private readonly IBL_Personas _bl;

        public PersonasController(IBL_Personas bl) {
            _bl = bl;
        }

        // GET: api/personas
        [HttpGet]
        public List<Persona> Get() {
            return _bl.Get();
        }

        // GET api/personas/5
        [HttpGet("{documento}")]
        public Persona Get(string documento, int test) {
            
            return _bl.Get(documento);
        }

        // POST api/personas
        [HttpPost]
        public void Post([FromBody] Persona persona) {
            _bl.Insert(persona);
        }

        // PUT api/personas/5
        [HttpPut("{id}")]
        public void Put([FromBody] Persona persona) {
            _bl.Update(persona);
        }

        // DELETE api/personas/5
        [HttpDelete("{id}")]
        public void Delete(string documento) {
            _bl.Delete(documento);
        }
    }
}
