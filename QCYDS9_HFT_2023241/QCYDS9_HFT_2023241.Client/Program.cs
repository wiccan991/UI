using QCYDS9_HFT_2023241.Models;
using QCYDS9_HFT_2023241.Repository;
using System;
using System.Linq;

namespace QCYDS9_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IRepository<Astronaut> repo = new AstronautRepository(new SpaceMissionContext());
            var items = repo.ReadAll().ToArray();

            ;
        }
    }
}
