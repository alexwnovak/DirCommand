using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DirCommand.UnitTest
{
   [TestClass]
   public class AppControllerTest
   {
      [TestInitialize]
      public void Initialize()
      {
         Dependency.CreateUnityContainer();
      }

      [TestMethod]
      public void Run_ArgumentsIsNull_FilesAreReadAndSentToTheConsole()
      {
         var files = new[]
         {
            "FileOne.txt",
            "FileTwo.txt"
         };

         // Setup

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fsm => fsm.GetFiles( It.IsAny<string>() ) ).Returns( files );
         Dependency.RegisterInstance( fileSystemMock.Object );

         var consoleAdapterMock = new Mock<IConsoleAdapter>();
         Dependency.RegisterInstance( consoleAdapterMock.Object );

         // Test

         var appController = new AppController();

         appController.Run( null );

         // Verify

         fileSystemMock.Verify( fsm => fsm.GetFiles( It.IsAny<string>() ), Times.Once() );
         consoleAdapterMock.Verify( cam => cam.WriteLine( files[0] ), Times.Once() );
         consoleAdapterMock.Verify( cam => cam.WriteLine( files[1] ), Times.Once() );
      }
   }
}
