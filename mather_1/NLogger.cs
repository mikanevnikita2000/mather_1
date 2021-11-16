using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mather_1
{
    class NLogger
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static void Nlog()
        {
            /*var msg = new LogEventInfo(LogLevel.Info, "", "This is a message");
            msg.Properties.Add("User", "Ray Donovan");*/
            logger.Info("");
            logger.Warn("");
            logger.Error(new Exception(), "This is an error message");


        }
       
    }
        
}
