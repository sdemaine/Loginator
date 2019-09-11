using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loginator
{
    public class Loginator
    {
        static StringBuilder allErrorMessages = new StringBuilder();
        static StringBuilder allInfoMessages = new StringBuilder();

        public static void Info(string message)
        {
            var logger = NLog.LogManager.GetLogger("AppLog");
            logger.Info(message);
        }

        public static void Error(string message)
        {
            var logger = NLog.LogManager.GetLogger("AppLog");
            logger.Error(message);
        }


        public static void AddInfoMessage(string message)
        {
            allInfoMessages.AppendLine(message);
        }

        public static void AddErrorMessage(string message)
        {
            allErrorMessages.AppendLine(message);
        }

        public static void AddExceptionMessage(string errorMessage, Exception ex)
        {
            if (errorMessage != string.Empty)
            {
                AddErrorMessage(errorMessage);
            }

            if (ex != null)
            {
                AddErrorMessage(ex.Message);
                if (ex.InnerException != null)
                {
                    AddErrorMessage("\t" + ex.InnerException.Message);
                }
            }
        }

        private static void LogAllErrorMessages()
        {
            var logger = NLog.LogManager.GetLogger("ErrorLog");
            if (allErrorMessages.Length > 0)
            {
                logger.Error(allErrorMessages.ToString());
            }
        }

        private static void LogAllInfoMessages()
        {
            var logger = NLog.LogManager.GetLogger("AppLog");
            if (allInfoMessages.Length > 0)
            {
                logger.Info(allInfoMessages.ToString());
            }
        }

        public static void LogAllMessages()
        {
            LogAllInfoMessages();
            LogAllErrorMessages();
        }
    }
}
