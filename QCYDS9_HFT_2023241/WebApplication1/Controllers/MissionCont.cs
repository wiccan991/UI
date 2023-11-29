using Microsoft.AspNetCore.Mvc;
using QCYDS9_HFT_2023241.Logic;
using QCYDS9_HFT_2023241.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QCYDS9_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MissionCont : ControllerBase
    {

        IMissionLogic mlogic;

        public MissionCont(IMissionLogic mlogic)
        {
            this.mlogic = mlogic;
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
        }

     
        [HttpPut]
        public void Update([FromBody] Mission value)
        {
            this.mlogic.Update(value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.mlogic.Delete(id);
        }
    }
}
