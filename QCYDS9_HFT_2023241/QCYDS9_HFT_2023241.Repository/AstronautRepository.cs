using QCYDS9_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCYDS9_HFT_2023241.Repository
{
    public class AstronautRepository : Repository<Astronaut>, IRepository<Astronaut>
    {
        public AstronautRepository(SpaceMissionContext ctx) : base(ctx)
        {
        }

        public override Astronaut Read(int id)
        {
            return ctx.Astronauts.FirstOrDefault(t => t.AstronautId == id);
        }

        public override void Update(Astronaut item)
        {
            var old = Read(item.AstronautId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
