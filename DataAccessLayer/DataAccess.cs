//Author - Mohsan Raza
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VideoManager.Logging;
using VideoManager.VideoDataModel;
namespace VideoManager.DataAccessLayer
{
    /// <summary>
    /// Data access for business layer
    /// </summary>
    public class DataAccess
    {
        /// <summary>
        /// Add video to db
        /// </summary>
        /// <param name="video"></param>
        /// <returns></returns>
        public DataTable AddVideo(Video video)
        {
            SqlCommand ObjSqlCommand = null;
            DataSet ObjDataSet = null;

            try
            {
                ObjSqlCommand = new SqlCommand("Proc_VM_AddNewVideo");
                ObjSqlCommand.CommandType = CommandType.StoredProcedure;
                ObjSqlCommand.Parameters.Add("@VideoID", SqlDbType.UniqueIdentifier).Value = video.VideoID;
                ObjSqlCommand.Parameters.Add("@UserName", SqlDbType.NChar, 30).Value = video.UserName;
                ObjSqlCommand.Parameters.Add("@Country", SqlDbType.NChar, 30).Value = video.Country;
                ObjSqlCommand.Parameters.Add("@City", SqlDbType.NChar, 30).Value = video.City;
                ObjSqlCommand.Parameters.Add("@VideoDescription", SqlDbType.NChar, 50).Value = video.VideoDescription;
                ObjSqlCommand.Parameters.Add("@VideoImagePath", SqlDbType.NChar, 100).Value = video.VideoImagePath;
                ObjSqlCommand.Parameters.Add("@VideoPath", SqlDbType.NChar, 100).Value = video.VideoPath;
                ObjSqlCommand.Parameters.Add("@UpDate", SqlDbType.DateTime).Value = video.UpDate;

                DataManager dataManager = new DataManager();
                ObjDataSet = dataManager.GetDataSet(ref ObjSqlCommand);
                if (ObjDataSet != null && ObjDataSet.Tables.Count > 0 && ObjDataSet.Tables[0].Rows.Count > 0)
                    return ObjDataSet.Tables[0];
                else
                    return null;
            }
            catch (Exception eObj)
            {
                Logger.Configure();
                Logger.log.Error(eObj.Message);
            }

            return null;
        }

        /// <summary>
        /// Get videos from db
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllVideos()
        {
            SqlCommand ObjSqlCommand = null;
            ObjSqlCommand = new SqlCommand("Select * from VM_Videos");
            ObjSqlCommand.CommandType = CommandType.Text;
            DataManager dataManager = new DataManager();
            return dataManager.GetDataSet(ref ObjSqlCommand);
        }

    }
}
