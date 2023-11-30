using Microsoft.AspNetCore.Mvc;
using QCYDS9_HFT_2023241.Logic;
using QCYDS9_HFT_2023241.Models;
using System.Collections.Generic;
using System.Numerics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QCYDS9_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExtraInfoCont : ControllerBase
    {
        IAstronautLogic alog;
        IMissionLogic mlog;

        public ExtraInfoCont(IAstronautLogic alog, IMissionLogic mlog)
        {
            this.alog = alog;
            this.mlog = mlog;
        }
        [HttpGet("{age}")]
        public IEnumerable<Astronaut> GetAstronautsYoungerThanX(int age)
        {
            return this.alog.GetAstronautsYoungerThanX(age);
        }

        [HttpGet]
        public int GetAmericansCountInfo()
        {
            return this.alog.GetAmericansCountInfo();
        }
        [HttpGet]
        public int GetYoungestAstonautAge()
        {
            return this.alog.GetYoungestAstonautAge();
        }
        [HttpGet("{missionId}")]
        public double AverageAstonautsAgeInMission(int missionId)
        {
            return this.mlog.AverageAstonautsAgeInMission(missionId);
                
        }

    }
}
