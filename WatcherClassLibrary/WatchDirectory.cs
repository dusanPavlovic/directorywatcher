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

        public WatchDirectory() : this(new FileProcessor())
        {
        }

        public WatchDirectory(IFileProcessor fileProcessor)
        {
            this._fileProcessor = fileProcessor;
        }

        public void StartDirectoryWatcher()
        {
            WatcherInitialization();
            while (isRunning)
            {
                Thread.Sleep(100);
            }
        }

        public string WorkDirectory
        {
            get { return ConfigurationManager.AppSettings["directory"]; }
        }

        public void Stop()
        {
            isRunning = false;
        }

        private void WatcherInitialization()
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
                catch (NotSupportedException e)
                {
                    logger.Error(e.Message);
                    Console.WriteLine("Application could not prepare enviorment");
                }
                catch (DirectoryNotFoundException e)
                {
                    logger.Error(e.Message);
                    Console.WriteLine("Application could not prepare enviorment");
                }
                catch (PathTooLongException e)
                {
                    logger.Error(e.Message);
                    Console.WriteLine("Application could not prepare enviorment");
                }
                catch (ArgumentNullException e)
                {
                    logger.Error(e.Message);
                    Console.WriteLine("Application could not prepare enviorment");
                }
                catch (ArgumentException e)
                {
                    logger.Error(e.Message);
                    Console.WriteLine("Application could not prepare enviorment");
                }
                catch (UnauthorizedAccessException e)
                {
                    logger.Error(e.Message);
                    Console.WriteLine("Application could not prepare enviorment");
                }
                catch (IOException e)
                {
                    logger.Error(e.Message);
                    Console.WriteLine("Application could not prepare enviorment");
                }
                catch (Exception e)
                {
                    logger.Error(e.Message);
                    Console.WriteLine("Application could not prepare enviorment");
                }
            }
        }
    }
}