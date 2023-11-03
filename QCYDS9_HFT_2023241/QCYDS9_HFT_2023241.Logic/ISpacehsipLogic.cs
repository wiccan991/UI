using QCYDS9_HFT_2023241.Models;
using System.Linq;

namespace QCYDS9_HFT_2023241.Logic
{
    public interface ISpacehsipLogic
    {
        void Create(Spaceship item);
        void Delete(int id);
        IQueryable<object> GetSpaceshipsAndMissionsAndAstronauts();
        Spaceship Read(int id);
        IQueryable<Spaceship> ReadAll();
        void Update(Spaceship item);
    }
}