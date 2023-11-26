using Microsoft.AspNetCore.Mvc;
using QCYDS9_HFT_2023241.Logic;
using QCYDS9_HFT_2023241.Models;
using System.Collections.Generic;

namespace QCYDS9_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CrewController : Controller
    {
        ISpacehsipLogic ill;

        public Crewnfo(ISpacehsipLogic ill)
        {
            this.ill = ill;
        }

       
        [HttpGet]
        public IEnumerable<Crewnfo> GetYSI()
        {
            return ill.Crewnfo();
        }
    }
}
