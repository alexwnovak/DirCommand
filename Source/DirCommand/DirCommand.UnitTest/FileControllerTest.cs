using System;
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

         var displayControllerMock = new Mock<IDisplayController>();
         Dependency.RegisterInstance( displayControllerMock.Object );

         // Test

         var fileController = new FileController();

         fileController.Run( new RunSettings() );

         // Assert

         fileSystemMock.Verify( fs => fs.GetFiles( RunSettings.DefaultPath ), Times.Once() );
      }

      [TestMethod]
      public void Run_HappyPath_ReadsFilesAndWritesThemToConsole()
      {
         var files = new FileEntry[3];

         // Setup

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.GetFiles( It.IsAny<string>() ) ).Returns( files );
         Dependency.RegisterInstance( fileSystemMock.Object );

         var displayControllerMock = new Mock<IDisplayController>();
         Dependency.RegisterInstance( displayControllerMock.Object );

         // Test

         var fileController = new FileController();

         fileController.Run( new RunSettings() );

         // Assert

         fileSystemMock.Verify( fs => fs.GetFiles( It.IsAny<string>() ), Times.Once() );
         displayControllerMock.Verify( dc => dc.Display( files ), Times.Once() );
      }
   }
}
