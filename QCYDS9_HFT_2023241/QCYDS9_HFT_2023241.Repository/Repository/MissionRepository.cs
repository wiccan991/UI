using QCYDS9_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCYDS9_HFT_2023241.Repository
{
    public class MissonRepository : Repository<Mission>, IRepository<Mission>
    {
        public MissonRepository(SpaceMissionContext ctx) : base(ctx)
        {
        }

        public override Mission Read(int id)
        {
            return ctx.Missions.FirstOrDefault(t => t.MissionId == id);
        }

        public override void Update(Mission item)
        {
            //var old = Read(item.MissionId);
            //foreach (var prop in old.GetType().GetProperties())
            //{
            //    prop.SetValue(old, prop.GetValue(item));
            //}
            //ctx.SaveChanges();

            var oldItem = Read(item.MissionId);
            foreach (var prop in oldItem.GetType().GetProperties())
            {
                //prop.SetValue(oldItem, prop.GetValue(item));

                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(oldItem, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
