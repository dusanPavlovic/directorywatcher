using Moq;
using NUnit.Framework;
using System.IO;
using WatcherClassLibrary;

namespace Watcher.Core.Test
{
    [TestFixture]
    public class FileProcessorFixtures
    {
        private Moq.Mock<ILog> _LogerMoq = new Mock<ILog>();
        private Mock<WatchDirectory> _watchDirectory = new Mock<WatchDirectory>();

        [Test]
        public void FileProcessor_Process_ShouldLogInfoMessage()
        {
            // Arrange

            var sut = new FileProcessor(_LogerMoq.Object);

            // Act

            string path = Path.Combine(_watchDirectory.Object.WorkDirectory, "test.txt");
            sut.Process(path);

            // Assert
            _LogerMoq.Verify(x => x.Info(It.IsAny<string>()));
        }

        [Test]
        public void FileProcessor_Process_ShouldLogErrorMessage()
        {
            // Arrange

            var sut = new FileProcessor(_LogerMoq.Object);

            // Act
            sut.Process(It.IsAny<string>());

            //Assert
            _LogerMoq.Verify(x => x.Error(It.IsAny<string>()));
        }
    }
}