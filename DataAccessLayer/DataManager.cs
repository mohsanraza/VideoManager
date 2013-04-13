//Author - Mohsan Raza
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoManager.SqlServerConnectionManager;
namespace VideoManager.DataAccessLayer
{
    public class DataManager
    {
        /// <summary>
        /// Execute command
        /// </summary>
        /// <param name="objSqlCommand"></param>
        /// <returns></returns>
        public DataSet GetDataSet(ref SqlCommand objSqlCommand)
        {
            SqlConnection objConn = new SqlConnection(ConnectionString.Get());
            objSqlCommand.Connection = objConn;

            DataSet objDataSet = new DataSet();
            SqlDataAdapter objSqlDataAdapter = new SqlDataAdapter();

            objSqlCommand.CommandTimeout = 1200;
            objSqlDataAdapter.SelectCommand = objSqlCommand;
            objSqlDataAdapter.Fill(objDataSet);

            objSqlCommand.Dispose();
            objSqlCommand = null;

            objSqlDataAdapter.Dispose();
            objSqlDataAdapter = null;

            objConn.Dispose();
            objConn = null;

            return objDataSet;

        }
    }
}
