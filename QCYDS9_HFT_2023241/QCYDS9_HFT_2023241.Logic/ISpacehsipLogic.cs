using QCYDS9_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QCYDS9_HFT_2023241.Logic
{
    public interface ISpacehsipLogic
    {
        void Create(Spaceship item);
        void Delete(int id);
        
        Spaceship Read(int id);
        IEnumerable<Spaceship> ReadAll();
        void Update(Spaceship item);

        IEnumerable<Crewnfo> CrewInfo();
        IEnumerable<Spaceship> GetSpaceshipsByAstronautCountry(string astronautCountry);
   


    }
}