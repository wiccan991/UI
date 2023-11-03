using QCYDS9_HFT_2023241.Models;
using QCYDS9_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCYDS9_HFT_2023241.Logic
{
    public class SpacehsipLogic
    {
        IRepository<Spaceship> repo;

        public SpacehsipLogic(IRepository<Spaceship> repo)
        {
            this.repo = repo;
        }

        public void Create(Spaceship item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Spaceship Read(int id)
        {
            var Spaceship = this.repo.Read(id);
            if (Spaceship == null)
            {
                throw new ArgumentException("Spaceship not exists.");
            }
            return this.repo.Read(id);
        }

        public IQueryable<Spaceship> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Spaceship item)
        {
            this.repo.Update(item);
        }
    }
}
