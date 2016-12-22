using Moq;
using NUnit.Framework;
using System.IO;
using System.Threading;
using WatcherClassLibrary;

namespace Watcher.Core.Test
{
    [TestFixture]
    public class WatchDirectoryTests
    {
        private Moq.Mock<IFileProcessor> _fileProcessorMoq = new Moq.Mock<IFileProcessor>();

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

        
    }
}