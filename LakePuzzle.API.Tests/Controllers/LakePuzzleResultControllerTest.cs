using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LakePuzzle.API;
using LakePuzzle.API.Controllers;

namespace LakePuzzle.API.Tests.Controllers
{
    [TestClass]
    public class LakePuzzleResultControllerTest
    {
        //TODO: Mock controller and make this a unit test rather than an integration test
        [TestMethod]
        public void GetLakePuzzleResultTest()
        {
            // Arrange
            LakePuzzleResultController controller = new LakePuzzleResultController();

            // Act
            var result = controller.GetLakePuzzleResult(3, 5, 4);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
