using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WatcherClassLibrary;


namespace Watcher
{
    class Program
    {
        static void Main(string[] args)
        {
            WatchDirectory watchDir = new WatchDirectory();
            watchDir.StartDirectoryWatcher(); 
        }


       
    }
}
