using Castle.Components.DictionaryAdapter.Xml;
using Moq;
using NUnit.Framework;
using QCYDS9_HFT_2023241.Logic;
using QCYDS9_HFT_2023241.Models;
using QCYDS9_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace QCYDS9_HFT_2023241.Test
{
    internal class CrewTest
    {

        AstronautLogic al;
        MissionLogic ml;
        SpacehsipLogic sl;
        Mock<IRepository<Astronaut>> mockAstronaut;
        Mock<IRepository<Mission>> mockMission;
        Mock<IRepository<Spaceship>> mockSpaceship;
        Crewnfo ci;

        [SetUp]
        public void Init()
        {
            mockAstronaut = new Mock<IRepository<Astronaut>>();
            mockMission = new Mock<IRepository<Mission>>();
            mockSpaceship = new Mock<IRepository<Spaceship>>();
            mockSpaceship.Setup(t => t.ReadAll()).Returns(new List<Spaceship>()
            {
                new Spaceship(1, "A", 10, 22),
                new Spaceship(2, "B", 20, 2020) 

            }.AsQueryable());
            mockMission.Setup(t => t.ReadAll()).Returns(new List<Mission>()
            {
                new Mission(1, 1, "A", 3550, "Lunar", 1989),
                new Mission(2, 2, "B ", 2500, "Mars Surface Exploration", 2011),
            }.AsQueryable());

            mockAstronaut.Setup(t => t.ReadAll()).Returns(new List<Astronaut>()
            {
                  new Astronaut(1,2,"Bruce Wayne","USA",35,true),
                 new Astronaut(2,1,"Clark Kent","Krypton",36,true),

                }.AsQueryable());

            al = new AstronautLogic(mockAstronaut.Object);
            ml = new MissionLogic(mockMission.Object);
            sl = new SpacehsipLogic(mockSpaceship.Object);
            ci = new Crewnfo(1, 1,"A");
        }
        [Test]
        public void CrewInfoTestCorrect()
        {
            Assert.That(ci.SpacehshipName != null);
        }
        [Test]
        public void CrewInfoTestCorrectTestWrong()
        {
            Assert.AreNotEqual(ci.MillioUSD, 32500);
        }
        [Test]
        public void CrewInfoTestCorrectIDNameTest()
        {
            Assert.AreEqual(ci.MissionId, 1);
        }
        [Test]
        public void CrewInfoTestCorrectIDNameTestWrong()
        {
            Assert.AreNotEqual(ci.MillioUSD, 2300);
        }
    }
}
      

