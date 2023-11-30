using QCYDS9_HFT_2023241.Models;
using QCYDS9_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.WebSockets;

namespace QCYDS9_HFT_2023241.Logic
{
    public class AstronautLogic : IAstronautLogic
    {
        IRepository<Astronaut> repo;
     
     

        public AstronautLogic(IRepository<Astronaut> repo)
        {
            this.repo = repo;
        }

        public void Create(Astronaut item)
        {
            if (item.Age < 0)
            {
                throw new ArgumentException("The astronaut age cannot be negative!");
            }
            else { this.repo.Create(item); }
           
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public IEnumerable<Astronaut> GetAstronautsYoungerThanX(int x)
        {
            return repo.ReadAll()
                .Where(t => t.Age < x);
        }
        
        public int GetYoungestAstonautAge()
        {
            return repo.ReadAll()
               .OrderBy(t => t.Age).First().Age;
        }

        public int GetAmericansCountInfo()
        {
            return repo.ReadAll()
               .Where(t => t.Country == "USA").Count();
              
        }

        public Astronaut Read(int id)
        {
            var astronaut = this.repo.Read(id);
            if (astronaut == null)
            {
                throw new ArgumentException("Astonaut nit exists.");
            }
            return this.repo.Read(id);
        }

        public IEnumerable<Astronaut> ReadAll()
        {
            return this.repo.ReadAll();
            
        }

        public void Update(Astronaut item)
        {
            this.repo.Update(item);
        }

       
    }
}
