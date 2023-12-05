using QCYDS9_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace QCYDS9_HFT_2023241.Logic
{
    public interface IMissionLogic
    {
        void Create(Mission item);
        void Delete(int id);
        Mission Read(int id);
        IEnumerable<Mission> ReadAll();
        void Update(Mission item);

        public double AverageAstonautsAgeInMission(int missionId);
        public IEnumerable<Mission> GetWomenInMission();
        public IEnumerable<Mission> GetMissionsByLaunchYear(int launchYear);
        public IEnumerable<Mission> GetMissionsBySpaceshipId(int spaceshipId);
    }
}