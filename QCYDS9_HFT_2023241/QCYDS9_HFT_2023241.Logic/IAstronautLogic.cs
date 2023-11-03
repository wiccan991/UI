using QCYDS9_HFT_2023241.Models;
using System.Linq;

namespace QCYDS9_HFT_2023241.Logic
{
    public interface IAstronautLogic
    {
        void Create(Astronaut item);
        void Delete(int id);
        Astronaut Read(int id);
        IQueryable<Astronaut> ReadAll();
        void Update(Astronaut item);
    }
}