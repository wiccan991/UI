using Microsoft.AspNetCore.Mvc;
using QCYDS9_HFT_2023241.Logic;
using QCYDS9_HFT_2023241.Models;
using System.Collections.Generic;
using System.Numerics;

namespace QCYDS9_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class InfoForMission : Controller
    {

        IAstronautLogic ial;
        IMissionLogic iml;

        public InfoForMission(IAstronautLogic ial, IMissionLogic iml)
        {
            this.ial = ial;
            this.iml = iml;
        }

        [HttpGet("{age}")]
        public IEnumerable<Astronaut> GetAstronautsYoungerThanX(int age)
        {
            return this.ial.GetAstronautsYoungerThanX(age);
        }
        [HttpGet]
        public int GetAmericansCountInfo()
        {
            return this.ial.GetAmericansCountInfo();
        }
        [HttpGet]
        public int GetYoungestAstonautAge()
        {
            return this.ial.GetYoungestAstonautAge();
        }
        [HttpGet("{tsId}")]
        public double AverageAstonautsAgeInMission(int tsId)
        {
            return this.iml.AverageAstonautsAgeInMission(tsId);
        }

    }
}
