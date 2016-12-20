using System;
using System.Threading;
using WatcherClassLibrary;

namespace Watcher
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WatchDirectory watchDir = new WatchDirectory();
            
            ThreadPool.QueueUserWorkItem((e) =>
            {
                watchDir.StartDirectoryWatcher();
            });
            var key = Console.ReadKey();
            watchDir.Stop();
        }
    }
}