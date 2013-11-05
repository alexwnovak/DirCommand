using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DirCommand.UnitTest
{
   [TestClass]
   public class DisplayControllerTest
   {
      [TestInitialize]
      public void Initialize()
      {
         Dependency.CreateUnityContainer();
      }

      [TestMethod]
      public void Display_FileIsExecutable_DisplaysExecutableWithColor()
      {
         const ConsoleColor exeColor = ConsoleColor.Green;
         const string fileName = "SomeExecutable.exe";
         var fileEntries = TestHelper.GetFileEntries( fileName );

         // Setup

         var consoleAdapterMock = new Mock<IConsoleAdapter>();
         Dependency.RegisterInstance( consoleAdapterMock.Object );

         var settingsRepoMock = new Mock<ISettingsRepository>();
         settingsRepoMock.Setup( sr => sr.GetExtensionColor( ".exe" ) ).Returns( exeColor );
         Dependency.RegisterInstance( settingsRepoMock.Object );

         // Test

         var displayController = new DisplayController();

         displayController.Display( new RunSettings(), fileEntries );

         // Assert

         consoleAdapterMock.Verify( ca => ca.WriteLine( fileName, ConsoleColor.Green ), Times.Once() );
      }

      [TestMethod]
      public void Run_PathContainsUppercaseFile_DisplaysProperColor()
      {
         const ConsoleColor exeColor = ConsoleColor.Green;
         const string fileName = "SomeExecutable.EXE";
         var fileEntries = TestHelper.GetFileEntries( fileName );

         // Setup

         var consoleAdapterMock = new Mock<IConsoleAdapter>();
         Dependency.RegisterInstance( consoleAdapterMock.Object );

         var settingsRepoMock = new Mock<ISettingsRepository>();
         settingsRepoMock.Setup( sr => sr.GetExtensionColor( ".exe" ) ).Returns( exeColor );
         Dependency.RegisterInstance( settingsRepoMock.Object );

         // Test

         var displayController = new DisplayController();

         displayController.Display( new RunSettings(), fileEntries );

         // Assert

         consoleAdapterMock.Verify( ca => ca.WriteLine( fileName, ConsoleColor.Green ), Times.Once() );
      }

      [TestMethod]
      public void Run_HasFileLength_LengthIsWrittenToConsole()
      {
         var fileEntry = new FileEntry
         {
            FullName = "SomeFile.txt",
            Length = 123456789
         };

         string expectedLengthString = SizeFormatter.GetSizeString( fileEntry.Length );

         // Setup

         var settingsRepoMock = new Mock<ISettingsRepository>();
         Dependency.RegisterInstance( settingsRepoMock.Object );

         var consoleAdapterMock = new Mock<IConsoleAdapter>();
         Dependency.RegisterInstance( consoleAdapterMock.Object );

         // Test

         var displayController = new DisplayController();

         displayController.Display( new RunSettings(), fileEntry.AsArray() );

         // Assert

         consoleAdapterMock.Verify( ca => ca.Write( expectedLengthString ), Times.Once() );
      }

      [TestMethod]
      public void Run_ContainsDirectory_DisplaysDirectoryCorrectly()
      {
         var fileEntry = new FileEntry
         {
            FullName = "ThisDirectory",
            IsDirectory = true
         };

         string actualString = string.Empty;

         // Setup

         var settingsRepoMock = new Mock<ISettingsRepository>();
         Dependency.RegisterInstance( settingsRepoMock.Object );

         var consoleAdapterMock = new Mock<IConsoleAdapter>();
         consoleAdapterMock.Setup( ca => ca.Write( It.IsAny<object>(), ConsoleColor.Magenta ) ).Callback<object, ConsoleColor>( ( s, c ) => actualString = s.ToString() );
         Dependency.RegisterInstance( consoleAdapterMock.Object );

         // Test

         var displayController = new DisplayController();

         displayController.Display( new RunSettings(), fileEntry.AsArray() );

         // Assert

         Assert.IsTrue( actualString.StartsWith( "Folder" ) );
      }
   }
}
