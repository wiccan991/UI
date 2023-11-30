using Microsoft.AspNetCore.Mvc;
using QCYDS9_HFT_2023241.Logic;
using QCYDS9_HFT_2023241.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QCYDS9_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpaceshipCont : ControllerBase
    {
        ISpacehsipLogic slogic;

        public SpaceshipCont(ISpacehsipLogic slogic)
        {
            this.slogic = slogic;
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
        }


        [HttpPut]
        public void Update([FromBody] Spaceship value)
        {
            this.slogic.Update(value);
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.slogic.Delete(id);
        }
    }
}
