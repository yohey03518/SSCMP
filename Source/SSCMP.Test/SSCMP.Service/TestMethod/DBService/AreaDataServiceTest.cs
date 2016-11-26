using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SSCMP.Test.Service.FakeClass;
using SSCMP.Service;
using SSCMP.Domain.DTO;
using System.Linq;
using System.Collections.Generic;

namespace SSCMP.Test.SSCMP.Service.TestMethod.DBService
{
    [TestClass]
    public class AreaDataServiceTest
    {
        [TestMethod]
        public void GetAllLevelAreaData()
        {
            // Arrange
            AreaDataService TargetAreaDataService = new AreaDataService();
            TargetAreaDataService.AreaDataRepo = new AreaDataRepositoryFake();

            // Act
            IList<AreaDTO> result = TargetAreaDataService.GetAllLevelAreaData();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.IsNotNull(result[0]);
            Assert.AreEqual(result[0].CodeName, "臺北市");
            Assert.AreEqual(result[1].CodeName, "高雄市");
            Assert.IsNotNull(result[0].TownshipList);
            Assert.IsNotNull(result[1].TownshipList);
            Assert.IsNotNull(result[1].TownshipList.Where(x => x.CodeName == "三民區"));
        }
    }
}
