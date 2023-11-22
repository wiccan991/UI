using Moq;
using NUnit.Framework;
using QCYDS9_HFT_2023241.Logic;
using QCYDS9_HFT_2023241.Models;
using QCYDS9_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCYDS9_HFT_2023241.Test
{
    [TestFixture]
    internal class SpaceshipTest
    {
        SpacehsipLogic spacelo;
        Mock<IRepository<Spaceship>> mockSpaceshipRepository;

        [SetUp]
        public void Init()
        {
            mockSpaceshipRepository = new Mock<IRepository<Spaceship>>();
            mockSpaceshipRepository.Setup(t => t.ReadAll()).Returns(new List<Spaceship>()
            {
               new Spaceship(1, "Apollo 11", 39937, 1969),
                new Spaceship(2, "Voyager 1", 61409, 1977),
                new Spaceship(3, "Space Shuttle Discovery", 27650, 1983),
            }.AsQueryable());

            spacelo = new SpacehsipLogic(mockSpaceshipRepository.Object);
        }
        [Test]
        public void SpaceshipCreateTestCorrect()
        {
            var spacesship = new Spaceship(1, "Apollo 12", 39937, 2002);
            spacelo.Create(spacesship);
            mockSpaceshipRepository.Verify(a => a.Create(spacesship), Times.Once());
        }
       
        [Test]
        public void SpaceshipReadTest()
        {

            try
            {
                spacelo.Read(10);
            }
            catch
            {

            }
            mockSpaceshipRepository.Verify(a => a.Read(10), Times.Once());
        }

        [Test]
        public void SpaceshipCreateTestIncorrect()
        {
            var space = new Spaceship(-91, "Apollo 12", 39937, 2002);
            try
            {
                spacelo.Create(space);
            }
            catch (ArgumentException)
            {
            }
            mockSpaceshipRepository.Verify(a => a.Create(space), Times.Never());
        }
    }
}
