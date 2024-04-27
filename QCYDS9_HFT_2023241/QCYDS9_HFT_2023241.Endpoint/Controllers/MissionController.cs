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
    public class MissionController : ControllerBase
    {

        IMissionLogic mlogic;
        IHubContext<SignalRHub> hub;

        public MissionController(IMissionLogic mlogic, IHubContext<SignalRHub> hub)
        {
            this.mlogic = mlogic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Mission> ReadAll()
        {
            return this.mlogic.ReadAll();
        }


        [HttpGet("{id}")]
        public Mission Read(int id)
        {
            return this.mlogic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Mission value)
        {
            this.mlogic.Create(value);
            hub.Clients.All.SendAsync("MissionCreated", value);
        }


        [HttpPut]
        public void Update([FromBody] Mission value)
        {
            this.mlogic.Update(value);

            hub.Clients.All.SendAsync("MissionUpdated", value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var MissionToDeleted = this.mlogic.Read(id);
            this.mlogic.Delete(id);
            hub.Clients.All.SendAsync("MissionDeleted", MissionToDeleted);
        }
    }
    }