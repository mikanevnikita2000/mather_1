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
            logger.Trace("");
            logger.Info("");
            logger.Warn("");
            logger.Error("");


        }
        /*public Form1()
        {

            InitializeComponent();

        }*/
    }
        
}
