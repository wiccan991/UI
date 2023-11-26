using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QCYDS9_HFT_2023241.Logic;
using QCYDS9_HFT_2023241.Models;
using System.Collections.Generic;

namespace QCYDS9_HFT_2023241.Endpoint.Controllers
{
    public class AstronautController : Controller
    {
        IAstronautLogic logic;

        public AstronautController(IAstronautLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Astronaut> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Astronaut Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Astronaut value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Astronaut value)
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
