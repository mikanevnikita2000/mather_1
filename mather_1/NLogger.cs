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
        public static void NlogInfo(bool startOrStopProgram)
        {
            if (startOrStopProgram == true)
            {
                logger.Info("start of the program");
            }
            else
            {
                logger.Info("stop of the program");
            }
        }
        public static void NlogWarnAnswer(bool correct_answer, string visibleExpression, int otvet)
        {
            logger.Warn($" example: {visibleExpression}; answer: {otvet}; correct_answer: {correct_answer}");
        }
        public static void NlogWarnBD()
        {
            logger.Warn("connect to DB");
        }
        public static void NlogErrorBD(string Message)
        {
            logger.Error($"don't connect to DB. Error: {Message}");
        }
        public static void NlogWarnInquiryBD(string executed)
        {
            logger.Warn($"boole the request is executed: {executed}");
        }

    }
        
}
