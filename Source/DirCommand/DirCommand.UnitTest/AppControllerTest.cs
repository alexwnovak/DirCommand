using System;
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

         var argumentParserMock = new Mock<IArgumentParser>();
         Dependency.RegisterInstance( argumentParserMock.Object );

         // Test

         var appController = new AppController();

         appController.Run( new string[1] );

         // Verify

         fileSystemMock.Verify( fsm => fsm.GetFiles( It.IsAny<string>() ), Times.Once() );
         displayControllerMock.Verify( cam => cam.Display( files ), Times.Once() );
      }

      [TestMethod]
      public void Run_HappyPath_ReturnsSuccessExitCode()
      {
         // Setup

         var fileSystemMock = new Mock<IFileSystem>();
         Dependency.RegisterInstance( fileSystemMock.Object );

         var displayControllerMock = new Mock<IDisplayController>();
         Dependency.RegisterInstance( displayControllerMock.Object );

         var argumentParserMock = new Mock<IArgumentParser>();
         Dependency.RegisterInstance( argumentParserMock.Object );

         // Test

         var appController = new AppController();

         int exitCode = appController.Run( null );

         // Verify

         Assert.AreEqual( 0, exitCode );
      }

      [TestMethod]
      public void Run_ArgumentsAreNull_NullArgumentsAreSentToParser()
      {
         // Setup

         var fileSystemMock = new Mock<IFileSystem>();
         Dependency.RegisterInstance( fileSystemMock.Object );

         var displayControllerMock = new Mock<IDisplayController>();
         Dependency.RegisterInstance( displayControllerMock.Object );

         var argumentParserMock = new Mock<IArgumentParser>();
         Dependency.RegisterInstance( argumentParserMock.Object );

         // Test

         var appController = new AppController();

         appController.Run( null );

         // Verify

         argumentParserMock.Verify( ap => ap.Parse( null ), Times.Once() );
      }

      [TestMethod]
      public void Run_HasArguments_ArgumentsAreSentToParser()
      {
         var arguments = new string[1];

         // Setup

         var fileSystemMock = new Mock<IFileSystem>();
         Dependency.RegisterInstance( fileSystemMock.Object );

         var displayControllerMock = new Mock<IDisplayController>();
         Dependency.RegisterInstance( displayControllerMock.Object );

         var argumentParserMock = new Mock<IArgumentParser>();
         Dependency.RegisterInstance( argumentParserMock.Object );

         // Test

         var appController = new AppController();

         appController.Run( arguments );

         // Verify

         argumentParserMock.Verify( ap => ap.Parse( arguments ), Times.Once() );
      }

      [TestMethod]
      public void Run_ArgumentParserEncountersUnrecognizedArgument_DisplaysErrorMessage()
      {
         const string errorMessage = "This is the error message";

         // Setup

         var argumentParserMock = new Mock<IArgumentParser>();
         argumentParserMock.Setup( ap => ap.Parse( It.IsAny<string[]>() ) ).Throws( new ArgumentException( errorMessage ) );
         Dependency.RegisterInstance( argumentParserMock.Object );

         var displayControllerMock = new Mock<IDisplayController>();
         Dependency.RegisterInstance( displayControllerMock.Object );

         // Test

         var appController = new AppController();

         appController.Run( null );

         // Assert

         displayControllerMock.Verify( dc => dc.ShowError( errorMessage ), Times.Once() );
      }

      [TestMethod]
      public void Run_ArgumentParserEncountersUnrecognizedArgument_ReturnsErrorExitCode()
      {
         const string errorMessage = "This is the error message";

         // Setup

         var argumentParserMock = new Mock<IArgumentParser>();
         argumentParserMock.Setup( ap => ap.Parse( It.IsAny<string[]>() ) ).Throws( new ArgumentException( errorMessage ) );
         Dependency.RegisterInstance( argumentParserMock.Object );

         var displayControllerMock = new Mock<IDisplayController>();
         Dependency.RegisterInstance( displayControllerMock.Object );

         // Test

         var appController = new AppController();

         int exitCode = appController.Run( null );

         // Assert

         Assert.AreEqual( 1, exitCode );
      }
   }
}
