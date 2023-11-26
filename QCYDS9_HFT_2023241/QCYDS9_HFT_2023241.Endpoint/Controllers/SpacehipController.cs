using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

namespace QCYDS9_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SpacehipController : ControllerBase
    {


            ISpacehsipLogic logic;

            public SpacehipController(ISpacehip logic)
            {
                this.logic = logic;
            }

            [HttpGet]
            public IEnumerable<League> ReadAll()
            {
                return this.logic.ReadAll();
            }

            [HttpGet("{id}")]
            public League Read(int id)
            {
                return this.logic.Read(id);
            }

            [HttpPost]
            public void Create([FromBody] League value)
            {
                this.logic.Create(value);
            }

            [HttpPut]
            public void Update([FromBody] League value)
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
}
