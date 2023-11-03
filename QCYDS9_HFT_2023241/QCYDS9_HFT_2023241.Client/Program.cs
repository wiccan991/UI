using QCYDS9_HFT_2023241.Logic;
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
            //Console.WriteLine("Hello World!");
            //IRepository<Astronaut> repo = new AstronautRepository(new SpaceMissionContext());
            //IRepository<Mission> repo2 = new MissonRepository(new SpaceMissionContext());

            //var items = repo2.ReadAll().ToArray();
            var ctx = new SpaceMissionContext();
            var repo = new AstronautRepository(ctx);
            var logic = new AstronautLogic(repo);

            var item = logic.ReadAll();

            ;
        }
    }
}
