using Microsoft.EntityFrameworkCore;
using QCYDS9_HFT_2023241.Models;
using QCYDS9_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCYDS9_HFT_2023241.Logic
{
    public class MissionLogic : IMissionLogic
    {
      
        IRepository<Mission> repo;


        public MissionLogic(IRepository<Mission> repo)
        {
            this.repo = repo;
        }

        public void Create(Mission item)
        {
            if (item.MissionId < 0)
            {
                throw new ArgumentException("The misiion ID cannot be negative!");
            }
            else
            {
                this.repo.Create(item);
            }
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Mission Read(int id)
        {
            var mission = this.repo.Read(id);
            if (mission == null)
            {
                throw new ArgumentException("Mission not exists.");
            }
            return this.repo.Read(id);
        }

        public IEnumerable<Mission> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Mission item)
        {
            this.repo.Update(item);
        }

        //Az összes küldetés listázása egy adott űrhajóhoz
        public IEnumerable<Mission> GetMissionsBySpaceshipId(int spaceshipId)
        {
            return this.repo.ReadAll().
                Where(m => m.SpaceshipId == spaceshipId).ToList();
        }

        //Küldetések, amiben nők is részt vettek
        public IEnumerable<Mission> GetWomenInMission()
        {

            var a = this.repo.ReadAll()
                .Where(a => a.Astronauts.Any(s => !s.IsMale))
                .ToList();

            return a;
        }

       

        //Az összes küldetés listázása egy adott évszám alapján:
        public IEnumerable<Mission> GetMissionsByLaunchYear(int launchYear)
        {
            return this.repo.ReadAll().
                Where(m => m.LaunchYear == launchYear).ToList();
        }

        //átlagosan  asztonauta életkora
        public double AverageAstonautsAgeInMission(int missionId)
        {
            var team = this.repo
            .ReadAll()
            .FirstOrDefault(t => t.MissionId == missionId);
            return team.Astronauts
            .Select(p => p.Age)
            .Average();
        }


    }
}
