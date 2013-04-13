using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoManager.VideoDataModel;

namespace VideoManager.Models
{
    public class VideoData

    {

        public Guid VideoID { get; set; }

        public String UserName { get; set; }
        public String Country { get; set; }

        public String City { get; set; }
        public String VideoDescription { get; set; }

        public String VideoImagePath { get; set; }
        public String VideoPath { get; set; }


        public DateTime UpDate { get; set; }
        
        
        
    }
}