using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QCYDS9_HFT_2023241.Logic;
using QCYDS9_HFT_2023241.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QCYDS9_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]

    public class ExtrainfoController : ControllerBase
    {
        IAstronautLogic alog;
        IMissionLogic mlog;
        ISpacehsipLogic slog;

        public ExtrainfoController(IAstronautLogic alog, IMissionLogic mlog, ISpacehsipLogic slog)
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
        [HttpGet("{astronautCountry}")]
        public IEnumerable<Spaceship> GetSpaceshipsByAstronautCountry(string astronautCountry) 
        {
            return this.slog.GetSpaceshipsByAstronautCountry(astronautCountry);
        }

        [HttpGet("{missionId}")]
       public IEnumerable<Astronaut> GetAstronautsByMissionId(int missionId)
        { 
            return this.alog.GetAstronautsByMissionId(missionId); 
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
