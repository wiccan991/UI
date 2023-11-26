using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using QCYDS9_HFT_2023241.Logic;
using QCYDS9_HFT_2023241.Models;

namespace QCYDS9_HFT_2023241.Endpoint.Controllers
{
    public class MissionController : Controller
    {
        IMissionLogic logic;

        public MissionController(IMissionLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Mission> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Mission Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Mission value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Mission value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
