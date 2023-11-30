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
    internal class MissionTest
    {
        MissionLogic misslo;
        Mock<IRepository<Mission>> mockMissionRepository;

        [SetUp]
        public void Init()
        {
            mockMissionRepository = new Mock<IRepository<Mission>>();
            mockMissionRepository.Setup(t => t.ReadAll()).Returns(new List<Mission>()
            {
                new Mission(1, 2, "A", 355000, "Moon", 1969),
                new Mission(2, 2, "B", 355000, "Moon", 1989),
                new Mission(3, 4, "B", 355000, "Moon", 1961),
              
            }.AsQueryable());
            misslo = new MissionLogic(mockMissionRepository.Object);
        }
        [Test]
        public void CreateTest()
        {
            var miss = new Mission(3, 4, "B", 355000, "Moon", 1961);
            misslo.Create(miss);
            mockMissionRepository.Verify(a => a.Create(miss), Times.Once());
        }
        
    }
}
