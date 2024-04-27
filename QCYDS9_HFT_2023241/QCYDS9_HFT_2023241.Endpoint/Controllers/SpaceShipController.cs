using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using QCYDS9_HFT_2023241.Endpoint.Services;
using QCYDS9_HFT_2023241.Logic;
using QCYDS9_HFT_2023241.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QCYDS9_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpaceShipController : ControllerBase
    {
        ISpacehsipLogic slogic;
        IHubContext<SignalRHub> hub;

        public SpaceShipController(ISpacehsipLogic slogic, IHubContext<SignalRHub> hub)
        {
            this.slogic = slogic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Spaceship> ReadAll()
        {
            return this.slogic.ReadAll();
        }


        [HttpGet("{id}")]
        public Spaceship Read(int id)
        {
            return this.slogic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Spaceship value)
        {
            this.slogic.Create(value);
            hub.Clients.All.SendAsync("SpaceshipCreated", value);
        }


        [HttpPut]
        public void Update([FromBody] Spaceship value)
        {
            this.slogic.Update(value);
            hub.Clients.All.SendAsync("SpaceshipCreated", value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var SpaceshipToDeleted = this.slogic.Read(id);
            this.slogic.Delete(id);
            hub.Clients.All.SendAsync("spaceshipDeleted", SpaceshipToDeleted);
        }
    }
}
