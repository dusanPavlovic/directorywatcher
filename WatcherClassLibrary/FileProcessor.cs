using System;
using System.Configuration;
using System.IO;
using System.Threading;

namespace WatcherClassLibrary
{
    public class FileProcessor : IFileProcessor
    {
        private ILog logger = new NLogAdapter();

        public FileProcessor(ILog _logger)
        {
            this.logger = _logger;
        }

        public FileProcessor() : this(new NLogAdapter())
        {
            
        }

        public void Process(string path)
        {
            try
            {
                int retries = int.Parse(ConfigurationManager.AppSettings["retries"]);

                for (int i = 0; i < retries; i++)
                {
                    try
                    {
                        string message = ReadFile(path);

                        logger.Info(message);
                        return;
                    }
                    catch (ArgumentException ex)
                    {
                        logger.Error(ex.Message);
                        Thread.Sleep(5000);
                    }
                    catch (DirectoryNotFoundException ex)
                    {
                        logger.Error(ex.Message);
                        Thread.Sleep(5000);
                    }
                    catch (FileNotFoundException ex)
                    {
                        logger.Error(ex.Message);
                        Thread.Sleep(5000);
                    }
                    catch (IOException ex)
                    {
                        logger.Error(ex.Message);
                        Thread.Sleep(5000);
                    }
                }
            }
            catch (ConfigurationErrorsException ex)
            {
                logger.Error(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                logger.Error(ex.Message);
            }
            catch (FormatException ex)
            {
                logger.Error(ex.Message);
            }
            catch (OverflowException ex)
            {
                logger.Error(ex.Message);
            }
        }

        private string ReadFile(string path)
        {
            using (StreamReader readtext = new StreamReader(path))
            {
                string text = readtext.ReadToEnd();
                return text;
            }
        }
    }
}