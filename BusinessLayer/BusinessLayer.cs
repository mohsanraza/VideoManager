//Author - Mohsan Raza
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoManager.DataAccessLayer;
using VideoManager.VideoDataModel;

namespace VideoManager.BusinessLayer
{
    public class BusinessLayer
    {
        /// <summary>
        /// Add new video
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        public bool AddVideo(Video video)
        {
            DataAccess dataAccess = new DataAccess();
            dataAccess.AddVideo(video);
            return true;
        }

        /// <summary>
        /// Get all videos
        /// </summary>
        /// <returns></returns>
        public List<Video> GetAllVideos()
        {
            List<Video> videos = new List<Video>();
            DataAccess dataAccess = new DataAccess();
            DataSet dataSet = dataAccess.GetAllVideos();
            foreach (DataRow dr in dataSet.Tables[0].Rows)
            {
                Video video = new Video();
                video.VideoID = (Guid)dr["VideoID"];
                video.UserName = (String)dr["UserName"];
                video.Country = (String)dr["Country"];
                video.City = (String)dr["City"];
                video.VideoDescription = (String)dr["VideoDescription"];
                video.VideoImagePath = (String)dr["VideoImagePath"];
                video.VideoPath = (String)dr["VideoPath"];
                video.UpDate = (DateTime)dr["Date"];
                videos.Add(video);
            }

            return videos;
        }
    }
}
