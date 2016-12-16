using NLog;

namespace WatcherClassLibrary
{
    internal class LoggerNlog
    {
        public void LogInfoMessageFromString(string textFormFile)
        {
            Logger logger = LogManager.GetCurrentClassLogger();

            logger.Info(textFormFile);
        }
    }
}