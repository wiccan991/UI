using QCYDS9_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace QCYDS9_HFT_2023241.Logic
{
    public interface IAstronautLogic
    {
        void Create(Astronaut item);
        void Delete(int id);
        Astronaut Read(int id);
        IEnumerable<Astronaut> GetAstronautsByMissionId(int missionId);
        IEnumerable<Astronaut> ReadAll();
        void Update(Astronaut item);
        IEnumerable<Astronaut> GetAstronautsYoungerThanX(int x);
        int GetYoungestAstonautAge();
        public int GetAmericansCountInfo();
    }
}