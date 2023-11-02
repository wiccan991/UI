using QCYDS9_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCYDS9_HFT_2023241.Repository
{
    public class SpaceshipRepository : Repository<Spaceship>, IRepository<Spaceship>
    {
        public SpaceshipRepository(SpaceMissionContext ctx) : base(ctx)
        {
        }

        public override Spaceship Read(int id)
        {
            return ctx.Spacehips.FirstOrDefault(t => t.Id == id);
        }

        public override void Update(Spaceship item)
        {
            var old = Read(item.Id);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
