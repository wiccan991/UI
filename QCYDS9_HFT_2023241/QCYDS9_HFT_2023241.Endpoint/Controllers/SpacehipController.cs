using Microsoft.AspNetCore.Mvc;
using QCYDS9_HFT_2023241.Logic;
using QCYDS9_HFT_2023241.Models;
using System.Collections.Generic;

namespace QCYDS9_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpacehipController : ControllerBase
    {


            ISpacehsipLogic logic;

            public SpacehipController(ISpacehsipLogic logic)
            {
                this.logic = logic;
            }

            [HttpGet]
            public IEnumerable<Spaceship> ReadAll()
            {
                return this.logic.ReadAll();
            }

            [HttpGet("{id}")]
            public Spaceship Read(int id)
            {
                return this.logic.Read(id);
            }

            [HttpPost]
            public void Create([FromBody] Spaceship value)
            {
                this.logic.Create(value);
            }

            [HttpPut]
            public void Update([FromBody] Spaceship value)
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

