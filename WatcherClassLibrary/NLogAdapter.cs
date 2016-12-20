using NLog;
using System;

namespace WatcherClassLibrary
{
    internal class NLogAdapter : ILog
    {
        private static ILogger Logger = LogManager.GetCurrentClassLogger();

        public void Debug()
        {
            throw new NotImplementedException();
        }

        public void Error(string message)
        {
            Logger.Error(message);
        }

        public void Fatal(string message)
        {
            Logger.Fatal(message);
        }

        public void Info(string message)
        {
            Logger.Info(message);
        }

        public void Warn()
        {
            throw new NotImplementedException();
        }
    }
}