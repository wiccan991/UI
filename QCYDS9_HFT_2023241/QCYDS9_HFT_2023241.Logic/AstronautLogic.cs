using QCYDS9_HFT_2023241.Models;
using QCYDS9_HFT_2023241.Repository;
using System;
using System.Linq;

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
            if (item.BornYear < 1900) throw new ArgumentException("Born year is not vaild.");
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
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

        public IQueryable<Astronaut> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Astronaut item)
        {
            this.repo.Update(item);
        }
    }
}
