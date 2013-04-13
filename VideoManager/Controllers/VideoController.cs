//Author - Mohsan Raza

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using VideoManager.Models;
using VideoManager.VideoDataModel;

namespace VideoManager.Controllers
{
    /// <summary>
    /// Video APIs
    /// </summary>
    public class VideoController : ApiController
    {
        

        // GET api/video
        public IEnumerable<VideoData> Get()
        {
            BusinessLayer.BusinessLayer bs = new BusinessLayer.BusinessLayer();
            VideoData[] list = GetVideoData(bs.GetAllVideos());
            return list;
        //}
            //return new string[] { "value1", "value2" };
        }

        // GET api/video/5
        public string Get(int id)
        {
            return "value";
        }
              // PUT api/video/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/video/5
        public void Delete(int id)
        {
        }

        /// <summary>
        /// Post videos with additional data
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> PostFile()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
           
            string root = HttpContext.Current.Server.MapPath("~/Videos");
            var provider = new MultipartFormDataStreamProvider(root);
            Video video = new Video();
            try
            {
                StringBuilder sb = new StringBuilder(); // Holds the response body

                // Read the form data and return an async task.
                await Request.Content.ReadAsMultipartAsync(provider);

                // This illustrates how to get the form data.
                foreach (var key in provider.FormData.AllKeys)
                {
                    foreach (var val in provider.FormData.GetValues(key))
                    {
                        if (key == "UserName")
                            video.UserName = val;

                        if (key == "Country")
                            video.Country = val;

                        if (key == "City")
                            video.City = val;

                        if (key == "VideoDescription")
                            video.VideoDescription = val;

                        if (key == "UserName")
                            video.UserName = val;

                    }
                }

                // This illustrates how to get the file names for uploaded files.
                foreach (var file in provider.FileData)
                {
                    HttpContentHeaders headers = file.Headers;
                    string fileName = headers.ContentDisposition.FileName.Replace("\"","");
                    string controlName = headers.ContentDisposition.Name.Replace("\"", "");
                    //file.LocalFileName = file.LocalFileName + file;
                    ///File.Replace(file.LocalFileName, file.LocalFileName + file,Guid.NewGuid().ToString());
                    File.Move(file.LocalFileName, file.LocalFileName + fileName);

                    FileInfo fileInfo = new FileInfo(file.LocalFileName);
                    if (controlName == "VideoImageFile")
                        video.VideoImagePath = GetSiteRootUrl() + "/videos/" + Path.GetFileName(file.LocalFileName + fileName);

                    if (controlName == "VideoFile")
                        video.VideoPath = GetSiteRootUrl() + "/videos/"+ Path.GetFileName(file.LocalFileName + fileName);

                   // sb.Append(string.Format("Uploaded file23: {0} ({1} bytes)\n", fileInfo.Name, fileInfo.Length));
                }

                BusinessLayer.BusinessLayer bs = new BusinessLayer.BusinessLayer();
                bs.AddVideo(video);

                return new HttpResponseMessage()
                {
                    Content = new StringContent(sb.ToString())
                };
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }

        private static string GetSiteRootUrl()
        {
            string protocol;

            if (HttpContext.Current.Request.IsSecureConnection)
                protocol = "https";
            else
                protocol = "http";

            StringBuilder uri = new StringBuilder(protocol + "://");

            string hostname = HttpContext.Current.Request.Url.Host;

            uri.Append(hostname);

            int port = HttpContext.Current.Request.Url.Port;

            if (port != 80 && port != 443)
            {
                uri.Append(":");
                uri.Append(port.ToString());
            }

            return uri.ToString();
        }
 
        public HttpResponseMessage Get(string id)
        {
            HttpResponseMessage result = null;
            var localFilePath = HttpContext.Current.Server.MapPath("~/" + id);

            // check if parameter is valid
            if (String.IsNullOrEmpty(id))
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            // check if file exists on the server
            else if (!File.Exists(localFilePath))
            {
                result = Request.CreateResponse(HttpStatusCode.Gone);
            }
            else
            {// serve the file to the client
                result = Request.CreateResponse(HttpStatusCode.OK);
                result.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = id;
            }

            return result;
        }
        private VideoData VideoDataConv(Video video)
        {
            VideoData vd = new VideoData();
            vd.VideoID = video.VideoID;
            vd.UserName = video.UserName;
            vd.Country = video.Country;
            vd.City = video.City;
            vd.VideoDescription = video.VideoDescription;
            vd.VideoPath = video.VideoPath;
            vd.VideoImagePath = video.VideoImagePath;
            return vd;
        }

        private Video VideoDataConv(VideoData video)
        {
            Video vd = new Video();
            vd.VideoID = video.VideoID;
            vd.UserName = video.UserName;
            vd.Country = video.Country;
            vd.City = video.City;
            vd.VideoDescription = video.VideoDescription;
            vd.VideoPath = video.VideoPath;
            vd.VideoImagePath = video.VideoImagePath;
            return vd;
        }


        private  VideoData[] GetVideoData(List<Video> videos)
        {
            List<VideoData> vDataList = new List<VideoData>();
            foreach (Video video in videos)
            {
                vDataList.Add(VideoDataConv(video));
            }

            return vDataList.ToArray();
        }
    }
}
