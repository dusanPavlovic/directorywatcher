using System;
using System.IO;

namespace WatcherClassLibrary
{
    public class WatchDirectory
    {
        public void StartDirectoryWatcher()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();

            if (!Directory.Exists("C:\\Directory"))
                Directory.CreateDirectory("C:\\Directory");

            string path = watcher.Path = "C:\\Directory";

            watcher.Filter = "*.*";

            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.NotifyFilter = NotifyFilters.LastAccess;
            watcher.NotifyFilter = NotifyFilters.DirectoryName;
            watcher.NotifyFilter = NotifyFilters.FileName;
            watcher.NotifyFilter = NotifyFilters.Size;

            watcher.Changed += Watcher_Changed;

            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Press \'q\' to quit.");
            while (Console.Read() != 'q') ;
        }

        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            string textFormFile = ReadTxtFile(e);

            LoggerNlog logobj = new LoggerNlog();
            logobj.LogInfoMessageFromString(textFormFile);
        }

        //private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        //{
        //    Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);

        //    using (StreamReader readtext = new StreamReader(e.FullPath))
        //    {
        //        string readMeText = readtext.ReadToEnd();
        //        Logger logger = LogManager.GetCurrentClassLogger();

        //        logger.Info(readMeText);
        //    }
        //}

        private static string ReadTxtFile(FileSystemEventArgs e)
        {
          

            try
            {
                using (StreamReader readtext = new StreamReader(e.FullPath))
                {
                    string readMeText = readtext.ReadLine();
                    return readMeText;
                }
            }
            catch (IOException ex)
            {
                throw;
            }
        }
    }
}