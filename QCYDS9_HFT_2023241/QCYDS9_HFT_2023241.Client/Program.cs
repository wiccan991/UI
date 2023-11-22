using ConsoleTools;
using Humanizer;
using QCYDS9_HFT_2023241.Logic;
using QCYDS9_HFT_2023241.Models;
using QCYDS9_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace QCYDS9_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;


        static void Create(string entity)
        {
            if (entity == "Spaceship")
            {
                Console.Write("Spaceship name: ");
                string name = Console.ReadLine();
                Console.Write("Spaceship speed: ");
                int speed = int.Parse(Console.ReadLine());
                Console.Write("Spaceship make year: ");
                int makeyear = int.Parse(Console.ReadLine());
              
                rest.Post(new Spaceship() { Name = name, MakeYear=makeyear, Speed=speed }, "spacehip");

            }
            else if (entity == "Astronaut")
            {
                Console.Write("Astronaut name: ");
                string name = Console.ReadLine();
                Console.Write("Astronaut age: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Astronaut country: ");
                string country = Console.ReadLine();
                Console.Write("Is astronaut male?(true/false): ");
                bool male = bool.Parse(Console.ReadLine());
                Console.Write("Astronaut mission ID: ");
                int id = int.Parse(Console.ReadLine());
                rest.Post(new Astronaut() {Name=name,Age=age,Country=country,IsMale=male, AstronautId= id }, "astronaut");
            }
            else if (entity == "Mission")
            {
                Console.Write("Mission name: ");
                string name = Console.ReadLine(); 
                Console.Write("Mission objective: ");
                string obj = Console.ReadLine();
                Console.Write("Mission spacehip ID: ");
                int Id = int.Parse(Console.ReadLine());
                Console.Write("Mission buget (million $): ");
                int budget = int.Parse(Console.ReadLine());
                Console.Write("Mission launch year: ");
                int launch = int.Parse(Console.ReadLine());
               
                rest.Post(new Mission() { Name = name, Objective=obj, MissionId=Id, BudgetMDollar=budget,LaunchYear=launch }, "mission");
            }
            Console.ReadLine();
        }
        static void List(string entity)
        {
            if (entity == "Spaceship")
            {
                List<Spaceship> spaceship = rest.Get<Spaceship>("spaceship");
                foreach (var item in spaceship)
                {
                    Console.WriteLine("(" + item.Id + ")" + item.Name);
                }
            }
            else if (entity == "Astronaut")
            {
                List<Astronaut> astro = rest.Get<Astronaut>("astronaut");
                foreach (var item in astro)
                {
                    Console.WriteLine("(" + item.AstronautId + ")" + item.Name);
                }
            }
            else if (entity == "Mission")
            {
                List<Mission> mission = rest.Get<Mission>("mission");
                foreach (var item in mission)
                {
                    Console.WriteLine("(" + item.MissionId + ")" + item.Name);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Spaceship")
            {
                Console.WriteLine("Spaceship ID to modify: ");
                int id = int.Parse(Console.ReadLine());
                Spaceship s = rest.Get<Spaceship>(id, "spaceship");
                Console.WriteLine($"Old name:{s.Name} new name: ");
                string newName = Console.ReadLine();
                s.Name = newName;
                rest.Put(s, "spaceship");

            }
            else if (entity == "Astronaut")
            {
                Console.WriteLine("Astronaut ID to modify: ");
                int id = int.Parse(Console.ReadLine());
                Astronaut a = rest.Get<Astronaut>(id, "astronaut");
                Console.WriteLine($"Old name:{t.Name} new name: ");
                string newName = Console.ReadLine();
                a.Name = newName;
                rest.Put(a, "astronaut");
            }
            else if (entity == "Player")
            {
                Console.WriteLine("Player ID to modify: ");
                int id = int.Parse(Console.ReadLine());
                Player p = rest.Get<Player>(id, "player");
                Console.WriteLine($"Old name:{p.Name} new name: ");
                string newName = Console.ReadLine();
                p.Name = newName;
                rest.Put(p, "player");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "League")
            {
                Console.WriteLine("League ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "league");
            }
            else if (entity == "Team")
            {
                Console.WriteLine("Team ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "team");
            }
            else if (entity == "Player")
            {
                Console.WriteLine("Player ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "player");
            }
        }
        static void YoungerThanX(string entity)
        {
            Console.WriteLine("Players under age: ");
            int age = int.Parse(Console.ReadLine());
            IEnumerable<Player> youngplayers = rest.Get<Player>("PlusInfo/GetPlayersYoungerThanX/" + age);
            foreach (var item in youngplayers)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
        static void YoungSalary(string entity)
        {
            int x = rest.GetSingle<int>("PlusInfo/GetYoungsterSalaryInfo");
            Console.WriteLine("U20 Players salary sum: " + x);
            Console.ReadLine();
        }
        static void YoungestPlayerAge(string entity)
        {
            int x = rest.GetSingle<int>("PlusInfo/GetYoungestPlayerAge");
            Console.WriteLine("The youngest player age is: " + x);
            Console.ReadLine();
        }
        static void AverageSalary(string entity)
        {
            Console.WriteLine("Team ID: ");
            int id = int.Parse(Console.ReadLine());
            double x = rest.GetSingle<double>("PlusInfo/AverageSalary/" + id);
            Console.WriteLine(x);
            Console.ReadKey();
        }
        static void YouthSquadInfo(string entity)
        {
            var ysi = rest.Get<YouthSquadInfo>("YouthSquadInfo/GetYSI");
            foreach (var item in ysi)
            {
                Console.WriteLine("League ID: " + item.LeagueId);
                Console.WriteLine("Youth Squad Counter: " + item.YouthSquadsInLeague);
            }
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:43006/", "league");
            var leagueSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("League"))
                .Add("Create", () => Create("League"))
                .Add("Delete", () => Delete("League"))
                .Add("Update", () => Update("League"))
                .Add("Youth Squad Info", () => YouthSquadInfo("League"))
                .Add("Exit", ConsoleMenu.Close);

            var teamSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Team"))
                .Add("Create", () => Create("Team"))
                .Add("Delete", () => Delete("Team"))
                .Add("Update", () => Update("Team"))
                .Add("Average salary", () => AverageSalary("Team"))
                .Add("Exit", ConsoleMenu.Close);

            var playerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Player"))
                .Add("Create", () => Create("Player"))
                .Add("Delete", () => Delete("Player"))
                .Add("Update", () => Update("Player"))
                .Add("Younger than X", () => YoungerThanX("Player"))
                .Add("Young players salary info", () => YoungSalary("Player"))
                .Add("Youngest player age", () => YoungestPlayerAge("Player"))
                .Add("Exit", ConsoleMenu.Close);
            var menu = new ConsoleMenu(args, level: 0)
                .Add("Leagues", () => leagueSubMenu.Show())
                .Add("Teams", () => teamSubMenu.Show())
                .Add("Players", () => playerSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    
    //static void Main(string[] args)
    //    {
    //        //Console.WriteLine("Hello World!");
    //        //IRepository<Astronaut> repo = new AstronautRepository(new SpaceMissionContext());
    //        //IRepository<Mission> repo2 = new MissonRepository(new SpaceMissionContext());

    //        //var items = repo2.ReadAll().ToArray();
            

       


    //        ;
        }
    }

