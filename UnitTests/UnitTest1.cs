using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoManager.Logging;
using VideoManager.BusinessLayer;
using VideoManager.VideoDataModel;
using System.Collections.Generic;
namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Logger.Configure();
            Logger.log.Error("logging test");
        }

        [TestMethod]
        public void TestMethod_AddVideo()
        {
            BusinessLayer bs = new BusinessLayer();

            Video video = new Video("Mohsan", "Pakistan", "Islamabad", "Test video", "abc", "def");

            bs.AddVideo(video);

        }
        
        [TestMethod]
        public void TestMethod_GetAllVideos()
        {
            BusinessLayer bs = new BusinessLayer();
            List<Video> list = new List<Video>();
             list = bs.GetAllVideos();

        }

    }
}
