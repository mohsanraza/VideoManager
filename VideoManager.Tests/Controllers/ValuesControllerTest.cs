using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoManager;
using VideoManager.Controllers;
using VideoManager.Models;

namespace VideoManager.Tests.Controllers
{
    [TestClass]
    public class ValuesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            VideoController controller = new VideoController();

            // Act
            IEnumerable<VideoData> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            VideoController controller = new VideoController();

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            VideoController controller = new VideoController();

            // Act
            //controller.Post("value");
            
            // Assert
        }

        [TestMethod]
        public void Put()
        {
           
            // Assert
        }

        [TestMethod]
        public void Delete()
        {
                 }
    }
}
