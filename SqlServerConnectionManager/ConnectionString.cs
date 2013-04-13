//Author - Mohsan Raza
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoManager.SqlServerConnectionManager
{
    public class ConnectionString 
    {
        /// <summary>
        /// Get connection string
        /// </summary>
        /// <returns></returns>
        public static string Get()
        {
            return @"Data Source=mohsanraza-vaio\SQLEXPRESS;Initial Catalog=VideoManager;UID=sa;PWD=Sql2008";
        }
    }
}
