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

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:25601/", "spaceship");
            var spaceshipSub = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Spaceship"))
                .Add("Create", () => Create("Spaceship"))
                .Add("Delete", () => Delete("Spaceship"))
                .Add("Update", () => Update("Spaceship"))
                .Add("Crew Info", () => CrewInfo("Spaceship"))
                .Add("Exit", ConsoleMenu.Close);

            var missionSub = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Mission"))
                .Add("Create", () => Create("Mission"))
                .Add("Delete", () => Delete("Mission"))
                .Add("Update", () => Update("Mission"))
                .Add("Average age in mission", () => AverageAstonautsAgeInMission("Mission"))
                .Add("Exit", ConsoleMenu.Close);

            var astronautSub = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Astronaut"))
                .Add("Create", () => Create("Astronaut"))
                .Add("Delete", () => Delete("Astronaut"))
                .Add("Update", () => Update("Astronaut"))
                .Add("Younger than X", () => YoungerThanX("Astronaut"))
                .Add("Number of American astronauts info", () => AmericansCountInf("Astronaut"))
                .Add("Youngest astronaut age", () => YoungestAstonautAge("Astronaut"))
                .Add("Exit", ConsoleMenu.Close);
            var menu = new ConsoleMenu(args, level: 0)
               .Add("Mission", () => missionSub.Show())
               .Add("Spaceship", () => spaceshipSub.Show())
               .Add("Astronaut", () => astronautSub.Show())
               .Add("Exit", ConsoleMenu.Close);

            menu.Show();

            //Console.WriteLine("Hello World!");
            //        //IRepository<Astronaut> repo = new AstronautRepository(new SpaceMissionContext());
            //        //IRepository<Mission> repo2 = new MissonRepository(new SpaceMissionContext());

            //        //var items = repo2.ReadAll().ToArray();


        }


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

                rest.Post(new Spaceship() { Name = name, MakeYear = makeyear, Speed = speed }, "Spaceship");

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
                rest.Post(new Astronaut() { Name = name, Age = age, Country = country, IsMale = male, AstronautId = id }, "Astronaut");
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

                rest.Post(new Mission() { Name = name, Objective = obj, MissionId = Id, BudgetMDollar = budget, LaunchYear = launch }, "Mission");
            }
            Console.ReadLine();
        }
        static void List(string entity)
        {
            if (entity == "Spaceship")
            {
                List<Spaceship> spaceship = rest.Get<Spaceship>("Spaceship");
                foreach (var item in spaceship)
                {
                    Console.WriteLine("(" + item.Id + ")" + item.Name);
                }
            }
            else if (entity == "Astronaut")
            {
                List<Astronaut> astro = rest.Get<Astronaut>("Astronaut");
                foreach (var item in astro)
                {
                    Console.WriteLine("(" + item.AstronautId + ")" + item.Name);
                }
            }
            else if (entity == "Mission")
            {
                List<Mission> mission = rest.Get<Mission>("Mission");
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
                Astronaut a = rest.Get<Astronaut>(id, "Astronaut");
                Console.WriteLine($"Old name:{a.Name} new name: ");
                string newName = Console.ReadLine();
                a.Name = newName;
                rest.Put(a, "Astronaut");
            }
            else if (entity == "Mission")
            {
                Console.WriteLine("Mission ID to modify: ");
                int id = int.Parse(Console.ReadLine());
                Mission m = rest.Get<Mission>(id, "Mission");
                Console.WriteLine($"Old name:{m.Name} new name: ");
                string newName = Console.ReadLine();
                m.Name = newName;
                rest.Put(m, "Mission");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Mission")
            {
                Console.WriteLine("Mission ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Mission");
            }
            else if (entity == "Astronaut")
            {
                Console.WriteLine("Astronaut ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Astronaut");
            }
            else if (entity == "Spaceship")
            {
                Console.WriteLine("Spaceship ID to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Spaceship");
            }
        }
        static void YoungerThanX(string entity)
        {
            Console.WriteLine("Astronaut under age: ");
            int age = int.Parse(Console.ReadLine());
            IEnumerable<Astronaut> youngastronauts = rest.Get<Astronaut>("PlusInfo/GetAstronautsYoungerThanX/" + age);
            foreach (var item in youngastronauts)
            {
                Console.WriteLine(item.Name);
            }
            Console.ReadLine();
        }
        static void AmericansCountInf(string entity)
        {
            int x = rest.GetSingle<int>("PlusInfo/GetAmericansCountInf");
            Console.WriteLine("Number of American astronauts: " + x);
            Console.ReadLine();
        }
        static void YoungestAstonautAge(string entity)
        {
            int x = rest.GetSingle<int>("PlusInfo/GetYoungestAstonautAge");
            Console.WriteLine("The youngest astronauts age is: " + x);
            Console.ReadLine();
        }
        static void AverageAstonautsAgeInMission(string entity)
        {
            Console.WriteLine("Mission ID: ");
            int id = int.Parse(Console.ReadLine());
            double x = rest.GetSingle<double>("PlusInfo/AverageAstonautsAgeInMission/" + id);
            Console.WriteLine(x);
            Console.ReadKey();
        }
        static void CrewInfo(string entity)
        {
            var ysi = rest.Get<Crewnfo>("Crewnfo/GetYSI");
            foreach (var item in ysi)
            {
                Console.WriteLine("Spaceship ID: " + item.MissionId);
                Console.WriteLine("MillioUSD: " + item.MillioUSD);
                Console.WriteLine("Name: " + item.SpacehshipName);
            }
            Console.ReadKey();
        }


    }
  }

