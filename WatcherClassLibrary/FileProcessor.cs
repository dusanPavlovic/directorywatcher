using System.IO;
using System.Threading;
using System.Timers;

namespace WatcherClassLibrary
{
    internal class FileProcessor
    {

        ILogg logger = new NLogAdapter();


        public void process(FileSystemEventArgs e)
        {


            System.Timers.Timer processTimer = new System.Timers.Timer();

            string message = ReadFile(e);




            if (message != null)
            {
                logger.Info(message);
            }
            
            

        }



        public string ReadFile(FileSystemEventArgs e)
        {
            string filecontent = "text fo log2";
            return filecontent;

            //try
            //{
            //    using (StreamReader readtext = new StreamReader(e.FullPath))
            //    {
            //        string readMeText = readtext.ReadLine();
            //        return readMeText;
            //    }
            //}
            //catch (IOException ex)
            //{
            //    throw ex;
            //}
        }

        public void LogInfoMessage(string message)
        {
            logger.Info(message);
        }
    }
}