using NLog;
using System;

namespace WatcherClassLibrary
{
    internal class NLogAdapter : ILogg
    {
        private static ILogger Logger = LogManager.GetCurrentClassLogger();

        public void Debug()
        {
            throw new NotImplementedException();
        }

        public void Error()
        {
            throw new NotImplementedException();
        }

        public void Fatal()
        {
            throw new NotImplementedException();
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