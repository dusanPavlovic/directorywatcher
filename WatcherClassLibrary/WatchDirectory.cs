using System;
using System.Configuration;
using System.IO;

namespace WatcherClassLibrary
{
    public class WatchDirectory
    {
        public void StartDirectoryWatcher()
        {
            FileSystemWatcher();
            Console.WriteLine("Press \'q\' to quit.");

            while (Console.Read() != 'q') ;
        }

        public void FileSystemWatcher()
        {
            string folder = PrepareEnviorment();

            FileSystemWatcher watcher = new FileSystemWatcher();

            watcher.Path = folder;

            watcher.Filter = "*.*";

            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.NotifyFilter = NotifyFilters.LastAccess;
            watcher.NotifyFilter = NotifyFilters.DirectoryName;
            watcher.NotifyFilter = NotifyFilters.FileName;
            watcher.NotifyFilter = NotifyFilters.Size;

            watcher.Changed += Watcher_Changed;

            watcher.EnableRaisingEvents = true;
        }

        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);

            FileProcessor procesFile = new FileProcessor();
            procesFile.process(e);
        }

        public static string PrepareEnviorment()
        {
            var folder = ConfigurationManager.AppSettings["directory"];

            if (!Directory.Exists(folder))
            {
                try
                {
                    Directory.CreateDirectory(folder);
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            return folder;
        }
    }
}