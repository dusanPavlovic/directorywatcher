namespace WatcherClassLibrary
{
    internal interface ILogg
    {
        void Info(string message);

        void Error();

        void Debug();

        void Warn();

        void Fatal();
    }
}