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

         var consoleAdapterMock = new Mock<IConsoleAdapter>();
         Dependency.RegisterInstance( consoleAdapterMock.Object );

         var settingsRepoMock = new Mock<ISettingsRepository>();
         Dependency.RegisterInstance( settingsRepoMock.Object );

         // Test

         var fileController = new FileController();

         fileController.Run( new RunSettings() );

         // Assert

         fileSystemMock.Verify( fs => fs.GetFiles( RunSettings.DefaultPath ), Times.Once() );
      }

      [TestMethod]
      public void Run_HappyPath_ReadsFilesAndWritesThemToConsole()
      {
         var files = new[]
         {
            "FileOne.txt",
            "FileTwo.txt",
            "FileThree.txt"
         };

         // Setup

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.GetFiles( It.IsAny<string>() ) ).Returns( files );
         Dependency.RegisterInstance( fileSystemMock.Object );

         var consoleAdapterMock = new Mock<IConsoleAdapter>();
         Dependency.RegisterInstance( consoleAdapterMock.Object );

         var settingsRepoMock = new Mock<ISettingsRepository>();
         Dependency.RegisterInstance( settingsRepoMock.Object );

         // Test

         var fileController = new FileController();

         fileController.Run( new RunSettings() );

         // Assert

         fileSystemMock.Verify( fs => fs.GetFiles( It.IsAny<string>() ), Times.Once() );
         consoleAdapterMock.Verify( ca => ca.WriteLine( It.IsAny<string>(), It.IsAny<ConsoleColor>() ), Times.Exactly( files.Length ) );
      }

      [TestMethod]
      public void Run_PathContainsExecutable_DisplaysExecutableWithColor()
      {
         const string fileName = "SomeExecutable.exe";
         const ConsoleColor exeColor = ConsoleColor.Green;

         // Setup

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.GetFiles( It.IsAny<string>() ) ).Returns( fileName.AsArray() );
         Dependency.RegisterInstance( fileSystemMock.Object );

         var consoleAdapterMock = new Mock<IConsoleAdapter>();
         Dependency.RegisterInstance( consoleAdapterMock.Object );

         var settingsRepoMock = new Mock<ISettingsRepository>();
         settingsRepoMock.Setup( sr => sr.GetExtensionColor( ".exe" ) ).Returns( exeColor );
         Dependency.RegisterInstance( settingsRepoMock.Object );

         // Test

         var fileController = new FileController();

         fileController.Run( new RunSettings() );

         // Assert

         consoleAdapterMock.Verify( ca => ca.WriteLine( fileName, ConsoleColor.Green ), Times.Once() );
      }

      [TestMethod]
      public void Run_PathContainsUppercaseFile_DisplaysProperColor()
      {
         const string fileName = "SomeExecutable.EXE";
         const ConsoleColor exeColor = ConsoleColor.Green;

         // Setup

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.GetFiles( It.IsAny<string>() ) ).Returns( fileName.AsArray() );
         Dependency.RegisterInstance( fileSystemMock.Object );

         var consoleAdapterMock = new Mock<IConsoleAdapter>();
         Dependency.RegisterInstance( consoleAdapterMock.Object );

         var settingsRepoMock = new Mock<ISettingsRepository>();
         settingsRepoMock.Setup( sr => sr.GetExtensionColor( ".exe" ) ).Returns( exeColor );
         Dependency.RegisterInstance( settingsRepoMock.Object );

         // Test

         var fileController = new FileController();

         fileController.Run( new RunSettings() );

         // Assert

         consoleAdapterMock.Verify( ca => ca.WriteLine( fileName, ConsoleColor.Green ), Times.Once() );
      }
   }
}
