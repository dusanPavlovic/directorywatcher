using System.Configuration;
using System.IO;
using System.Threading;

namespace WatcherClassLibrary
{
    internal class FileProcessor
    {
        private ILogg logger = new NLogAdapter();

        public void Process(FileSystemEventArgs e)
        {
            int retries = int.Parse(ConfigurationManager.AppSettings["retries"]);

            for (int i = 0; i < retries; i++)
            {
                try
                {
                    string message = ReadFile(e);

                    LogInfoMessage(message);
                    return;
                }
                catch (IOException ex)
                {
                    LogErrorMessage(ex.Message);

                    Thread.Sleep(5000);
                }
            }
        }

        private string ReadFile(FileSystemEventArgs e)
        {
            using (StreamReader readtext = new StreamReader(e.FullPath))
            {
                string text = readtext.ReadLine();
                return text;
            }
        }

        public void LogInfoMessage(string message)
        {
            logger.Info(message);
        }

        public void LogErrorMessage(string messaage)
        {
            logger.Error(messaage);
        }
    }
}