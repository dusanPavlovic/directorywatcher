namespace WatcherClassLibrary
{
    internal interface ILog
    {
        void Info(string message);

        void Error(string message);

        void Debug();

        void Warn();

        void Fatal(string message);
    }
}