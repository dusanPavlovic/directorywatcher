namespace WatcherClassLibrary
{
    internal interface ILogg
    {
        void Info(string message);

        void Error(string message);

        void Debug();

        void Warn();

        void Fatal();
    }
}