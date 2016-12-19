using WatcherClassLibrary;

namespace Watcher
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WatchDirectory watchDir = new WatchDirectory();
            watchDir.StartDirectoryWatcher();
        }
    }
}