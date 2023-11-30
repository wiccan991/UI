using Microsoft.AspNetCore.Mvc;
using QCYDS9_HFT_2023241.Logic;
using QCYDS9_HFT_2023241.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QCYDS9_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class ExtraInfoCont : ControllerBase
    {
        IAstronautLogic alog;
        IMissionLogic mlog;
        ISpacehsipLogic slog;

        public ExtraInfoCont(IAstronautLogic alog, IMissionLogic mlog, ISpacehsipLogic slog)
        {
            this.alog = alog;
            this.mlog = mlog;
            this.slog = slog;
      
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
        public IEnumerable<Mission> GetWomenInMission()
        {

            return this.mlog.GetWomenInMission();
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
