using System;
using System.Configuration;
using System.IO;
using System.Threading;

namespace WatcherClassLibrary
{
    public class WatchDirectory
    {
        private ILog logger = new NLogAdapter();

        private IFileProcessor _fileProcessor;

        private bool isRunning = true;

        public WatchDirectory() : this(new FileProcessor()) { }

        public WatchDirectory(IFileProcessor fileProcessor)
        {
            this._fileProcessor = fileProcessor;
        }

        public void StartDirectoryWatcher()
        {
            FileSystemWatcher();
            while (isRunning)
            {
                Thread.Sleep(100);
            }
        }

        public string WorkDirectory
        {
            get {  return ConfigurationManager.AppSettings["directory"]; }
        }

        public void Stop()
        {
            isRunning = false;
        }

        private void FileSystemWatcher()
        {
            PrepareEnviorment();

            FileSystemWatcher watcher = new FileSystemWatcher();

            watcher.Path = WorkDirectory;

            watcher.Filter = "*.*";

            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.NotifyFilter = NotifyFilters.LastAccess;
            watcher.NotifyFilter = NotifyFilters.DirectoryName;
            watcher.NotifyFilter = NotifyFilters.FileName;
            watcher.NotifyFilter = NotifyFilters.Size;

            watcher.Changed += Watcher_Changed;

            watcher.EnableRaisingEvents = true;
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
            _fileProcessor.Process(e.FullPath);
        }

        public void PrepareEnviorment()
        {

            if (!Directory.Exists(WorkDirectory))
            {
                try
                {
                    Directory.CreateDirectory(WorkDirectory);
                }
                catch (UnauthorizedAccessException e)
                {
                    // sve ide logger
                    logger.Error(e.Message);
                    Console.WriteLine(e.Message);
                   
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }
}