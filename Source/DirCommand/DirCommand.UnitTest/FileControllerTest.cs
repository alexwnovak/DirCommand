using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DirCommand.UnitTest
{
   [TestClass]
   public class FileControllerTest
   {
      [TestInitialize]
      public void Initialize()
      {
         Dependency.CreateUnityContainer();
      }

      [TestMethod]
      public void Run_DefaultRunSettings_ReadsFilesFromCurrentDirectory()
      {
         // Setup

         var fileSystemMock = new Mock<IFileSystem>();
         Dependency.RegisterInstance( fileSystemMock.Object );

         // Run

         var fileController = new FileController();

         fileController.Run( new RunSettings() );

         // Assert

         fileSystemMock.Verify( fs => fs.GetFiles( RunSettings.DefaultPath ), Times.Once() );
      }
   }
}
