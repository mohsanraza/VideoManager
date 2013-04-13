//Author - Mohsan Raza

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoManager.VideoDataModel
{
    public class Video
    {
        Guid _videoID;

        public Guid VideoID
        {
            get { return _videoID; }
            set { _videoID = value; }
        }
        String _userName;

        public String UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        String _Country;

        public String Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
        String _city;

        public String City
        {
            get { return _city; }
            set { _city = value; }
        }
        String _videoDescription;

        public String VideoDescription
        {
            get { return _videoDescription; }
            set { _videoDescription = value; }
        }
        String _videoImagePath;

        public String VideoImagePath
        {
            get { return _videoImagePath; }
            set { _videoImagePath = value; }
        }
        String _videoPath;

        public String VideoPath
        {
            get { return _videoPath; }
            set { _videoPath = value; }
        }
        DateTime _upDate;

        public DateTime UpDate
        {
            get { return _upDate; }
            set { _upDate = value; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Video()
        {
            _videoID = System.Guid.NewGuid();
            _userName = "New User";
            _Country = "New country";
            _city = "New City";
            _videoDescription = "Video Description";
            _videoImagePath = "path";
            _videoPath = "path";
            _upDate = DateTime.Now; 
        }

        /// <summary>
        /// Video constructor
        /// </summary>
        /// <param name="VideoID"></param>
        /// <param name="UserName"></param>
        /// <param name="Country"></param>
        /// <param name="City"></param>
        /// <param name="VideoDescription"></param>
        /// <param name="VideoImagePath"></param>
        /// <param name="VideoPath"></param>
        /// <param name="UpDate"></param>
        public Video(Guid VideoID, String UserName, String Country, String City, String VideoDescription, String VideoImagePath, String VideoPath, DateTime UpDate)
        {
            _videoID = VideoID;
            _userName = UserName;
            _Country = Country;
            _city = City;
            _videoDescription = VideoDescription;
            _videoImagePath = VideoImagePath;
            _videoPath = VideoPath;
            _upDate = UpDate;
        }

        /// <summary>
        /// Video Constructor
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Country"></param>
        /// <param name="City"></param>
        /// <param name="VideoDescription"></param>
        /// <param name="VideoImagePath"></param>
        /// <param name="VideoPath"></param>
        public Video(String UserName, String Country, String City, String VideoDescription, String VideoImagePath, String VideoPath)
        {
            _videoID = System.Guid.NewGuid();
            _userName = UserName;
            _Country = Country;
            _city = City;
            _videoDescription = VideoDescription;
            _videoImagePath = VideoImagePath;
            _videoPath = VideoPath;
            _upDate = DateTime.Now;
        }
    }
}
