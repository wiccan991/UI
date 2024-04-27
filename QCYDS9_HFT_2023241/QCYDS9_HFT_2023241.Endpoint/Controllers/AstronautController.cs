using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using QCYDS9_HFT_2023241.Endpoint.Services;
using QCYDS9_HFT_2023241.Logic;
using QCYDS9_HFT_2023241.Models;
using System.Collections.Generic;
using System.Numerics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QCYDS9_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AstronautController : ControllerBase
    {

        IAstronautLogic alogic;
        IHubContext<SignalRHub> hub;
        public AstronautController(IAstronautLogic alogic, IHubContext<SignalRHub> hub)
        {
            this.alogic = alogic;
            this.hub = hub;
        }
        
        // GET: api/<AstonautController>
        [HttpGet]
        public IEnumerable<Astronaut> ReadAll()
        {
            return this.alogic.ReadAll();
        }

        // GET api/<AstonautController>/5
        [HttpGet("{id}")]
        public Astronaut Read(int id)
        {
            return this.alogic.Read(id);
        }

        // POST api/<AstonautController>
        [HttpPost]
        public void Create([FromBody] Astronaut value)
        {
            this.alogic.Create(value);
            hub.Clients.All.SendAsync("AstonautCreated", value);

        }

        // PUT api/<AstonautController>/5
        [HttpPut]
        public void Update([FromBody] Astronaut value)
        {
            this.alogic.Update(value);
            hub.Clients.All.SendAsync("AstonautUpdated", value);
        }

        // DELETE api/<AstonautController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var AstonautToDeleted = this.alogic.Read(id);
            this.alogic.Delete(id);
            hub.Clients.All.SendAsync("AstonautDeleted",  AstonautToDeleted);
        }

    }
}