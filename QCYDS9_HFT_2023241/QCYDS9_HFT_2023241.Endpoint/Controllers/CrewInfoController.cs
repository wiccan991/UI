using Microsoft.AspNetCore.Mvc;
using QCYDS9_HFT_2023241.Logic;
using QCYDS9_HFT_2023241.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace QCYDS9_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CrewInfoController : ControllerBase
    {
        ISpacehsipLogic slog;

        public CrewInfoController(ISpacehsipLogic slog)
        {
            this.slog = slog;
        }

        [HttpGet]
        public IEnumerable<Crewnfo> CrewInfo()
        {
            return slog.CrewInfo();
        }
    }
}
