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
    public class SpacehsipLogic : ISpacehsipLogic
    {
        IRepository<Spaceship> repo;
      

        public SpacehsipLogic(IRepository<Spaceship> repo)
        {
            this.repo = repo;
            
        }

        


        public void Create(Spaceship item)
        {
            if (item.Id < 0)
            {
                throw new ArgumentException("The spaceship ID cannot be negative!");
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

        public Spaceship Read(int id)
        {
            var mission = this.repo.Read(id);
            if (mission == null)
            {
                throw new ArgumentException("Astonaut not exists.");
            }
            return this.repo.Read(id);
        }

        public IEnumerable<Spaceship> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Spaceship item)
        {
            this.repo.Update(item);
        }
        //Az összes űrhajó listázása egy adott országban részt vevő űrhajósok alapján
        public IEnumerable<Spaceship> GetSpaceshipsByAstronautCountry(string astronautCountry)
        {
            return this.repo.ReadAll()
                .Where(s => s.Missions.Any(m => m.Astronauts.Any(a => a.Country == astronautCountry)))
                .ToList();
        }


        public IEnumerable<Crewnfo> CrewInfo()
        {

            return this.repo.ReadAll()
            .SelectMany(t => t.Missions)
            .GroupBy(t => t.MissionId)
            .Select(g => new Crewnfo()
            {

                MissionId = g.Key,

                SpacehshipName = repo.Read(g.Key).Name,
                MillioUSD = g.Sum(t=>t.BudgetMDollar)
            }); ;

        }

    }
}
