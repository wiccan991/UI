using Microsoft.AspNetCore.Mvc;
using QCYDS9_HFT_2023241.Logic;
using QCYDS9_HFT_2023241.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QCYDS9_HFT_2023241.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AstonautController : ControllerBase
    {

        IAstronautLogic alogic;

        public AstonautController(IAstronautLogic alogic)
        {
            this.alogic = alogic;
        }

        // GET: api/<AstonautController>
        [HttpGet]
        public IEnumerable<Astronaut> ReadAll()
        {
            return this.alogic.ReadAll();
        }

        // GET api/<AstonautController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AstonautController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AstonautController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AstonautController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
