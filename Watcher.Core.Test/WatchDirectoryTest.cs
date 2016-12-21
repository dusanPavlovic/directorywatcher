using System;
using NUnit.Framework;
using System.IO;
using System.Collections.Generic;
using WatcherClassLibrary;
using Moq;
using System.Threading;

namespace Watcher.Core.Test
{
    [TestFixture]
    public class WatchDirectoryTests
    {
        Moq.Mock<IFileProcessor> _fileProcessorMoq = new Moq.Mock<IFileProcessor>();

        [Test]
        public void Watcher_StartDirectoryWatcher_ShouldHandleEvent()
        {
            // Arrange
            var watchDirectory = new WatchDirectory(_fileProcessorMoq.Object);

            // Act
            ThreadPool.QueueUserWorkItem((e) =>
            {
                Thread.Sleep(2000);
                using (var file = File.CreateText(Path.Combine(watchDirectory.WorkDirectory, "test.txt")))
                {
        
                    file.WriteLine("Hello from test method: Watcher_StartDirectoryWatcher_ShouldHandleEvent  ");
                }
                Thread.Sleep(1000);
                watchDirectory.Stop();
            });

            watchDirectory.StartDirectoryWatcher();
            

            // Assert
            _fileProcessorMoq.Verify(x => x.Process(It.IsAny<string>()));           
        }

        //[Test]
        //// [ExpectedException("System.IOException")] kada ovo?

        //public void Watcher_StartDirectoryWatcher_ShouldCatchException()
        //{
        //    //Arrange
        //    var watchDirectory = new WatchDirectory(_fileProcessorMoq.Object);

        //    //Act

           
           
        //    ThreadPool.QueueUserWorkItem((e) => {
              

        //        Thread.Sleep(2000);
        //    var file = File.CreateText(Path.Combine(watchDirectory.WorkDirectory, "test.txt"));
        //        file.WriteLine("Hello from test method: Watcher_StartDirectoryWatcher_ShouldCatchException");
        //        Thread.Sleep(5000);
        //        file.Close();
        //        Thread.Sleep(2000);



        //        watchDirectory.Stop();

        //    });

        //    watchDirectory.StartDirectoryWatcher();


        //    //Assert

        //    Assert.That(() => watchDirectory.StartDirectoryWatcher(), Throws.TypeOf<IOException>());


        //    Assert.Throws<IOException>(() =>
        //    {

        //        _fileProcessorMoq.Object.Process(It.IsAny<string>());

        //    });
        //}
    }
}
