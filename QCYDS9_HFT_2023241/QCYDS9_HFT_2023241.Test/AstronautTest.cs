using Moq;
using NUnit.Framework;
using QCYDS9_HFT_2023241.Logic;
using QCYDS9_HFT_2023241.Models;
using QCYDS9_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace QCYDS9_HFT_2023241.Test
{
    [TestFixture]
    internal class AstronautTest
    {
        AstronautLogic astrolo;
        Mock<IRepository<Astronaut>> mockAstronautRepository;
        [SetUp]
        public void Init()
        {
            mockAstronautRepository = new Mock<IRepository<Astronaut>>();
            astrolo = new AstronautLogic(mockAstronautRepository.Object);
        }
        [Test]
        public void CreateTest()
        {
            var astro = new Astronaut(1,3,"Bruce Wayne","USA",35,true);
            astrolo.Create(astro);
            mockAstronautRepository.Verify(a => a.Create(astro), Times.Once());
        }
        [Test]
        public void GetYoungestAstonautAge()
        {
            mockAstronautRepository.Setup(t => t.ReadAll()).Returns(new List<Astronaut>()
            {
                new Astronaut(1,2,"Bruce Wayne","USA",35,true),
                new Astronaut(2,1,"Clark Kent","Krypton",36,true),
                new Astronaut(3,3,"Hal Jordan","USA",27,true)
            }.AsQueryable());
            astrolo = new AstronautLogic(mockAstronautRepository.Object);
            Assert.AreEqual(astrolo.GetYoungestAstonautAge(), 27);
        }
    }

}

