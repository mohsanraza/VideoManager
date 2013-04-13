//Author - Mohsan Raza
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VideoManager.Logging
{
    public class Logger
    {
        public static ILog log = log4net.LogManager.GetLogger(typeof(Logger));
        private static bool configured = false;
        
        /// <summary>
        /// configure logger
        /// </summary>
         public static void Configure()
        {
            if (!configured)
            {
                string fullPath = System.Reflection.Assembly.GetAssembly(typeof(Logger)).Location;

               string theDirectory = Path.GetDirectoryName(fullPath);

                FileInfo info = new FileInfo(Path.Combine(theDirectory, "Logger.dll.config"));
                if(!info.Exists)
                    info = new FileInfo(Path.Combine(@"D:\Projects\Assignment\VideoManager\Logging\bin\Debug", "Logger.dll.config"));
                log4net.Config.XmlConfigurator.Configure(info);


                configured = true;
            }
        }
    }
}
