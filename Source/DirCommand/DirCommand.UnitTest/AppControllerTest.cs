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
      public void Run_ArgumentsIsNull_FilesAreReadAndSentToTheDisplayController()
      {
         var files = new string[0];

         // Setup

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fsm => fsm.GetFiles( It.IsAny<string>() ) ).Returns( files );
         Dependency.RegisterInstance( fileSystemMock.Object );

         var displayControllerMock = new Mock<IDisplayController>();
         Dependency.RegisterInstance( displayControllerMock.Object );

         // Test

         var appController = new AppController();

         appController.Run( null );

         // Verify

         fileSystemMock.Verify( fsm => fsm.GetFiles( It.IsAny<string>() ), Times.Once() );
         displayControllerMock.Verify( cam => cam.Display( files ), Times.Once() );
      }
   }
}
