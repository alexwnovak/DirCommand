using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DirCommand.UnitTest
{
   [TestClass]
   public class DisplayControllerTest
   {
      //[TestMethod]
      //public void Run_PathContainsExecutable_DisplaysExecutableWithColor()
      //{
      //   const ConsoleColor exeColor = ConsoleColor.Green;
      //   const string fileName = "SomeExecutable.exe";
      //   var fileEntries = TestHelper.GetFileEntries( fileName );

      //   // Setup

      //   var fileSystemMock = new Mock<IFileSystem>();
      //   fileSystemMock.Setup( fs => fs.GetFiles( It.IsAny<string>() ) ).Returns( fileEntries );
      //   Dependency.RegisterInstance( fileSystemMock.Object );

      //   var consoleAdapterMock = new Mock<IConsoleAdapter>();
      //   Dependency.RegisterInstance( consoleAdapterMock.Object );

      //   var settingsRepoMock = new Mock<ISettingsRepository>();
      //   settingsRepoMock.Setup( sr => sr.GetExtensionColor( ".exe" ) ).Returns( exeColor );
      //   Dependency.RegisterInstance( settingsRepoMock.Object );

      //   // Test

      //   var fileController = new FileController();

      //   fileController.Run( new RunSettings() );

      //   // Assert

      //   consoleAdapterMock.Verify( ca => ca.WriteLine( fileName, ConsoleColor.Green ), Times.Once() );
      //}

      //[TestMethod]
      //public void Run_PathContainsUppercaseFile_DisplaysProperColor()
      //{
      //   const ConsoleColor exeColor = ConsoleColor.Green;
      //   const string fileName = "SomeExecutable.EXE";
      //   var fileEntries = TestHelper.GetFileEntries( fileName );

      //   // Setup

      //   var fileSystemMock = new Mock<IFileSystem>();
      //   fileSystemMock.Setup( fs => fs.GetFiles( It.IsAny<string>() ) ).Returns( fileEntries );
      //   Dependency.RegisterInstance( fileSystemMock.Object );

      //   var consoleAdapterMock = new Mock<IConsoleAdapter>();
      //   Dependency.RegisterInstance( consoleAdapterMock.Object );

      //   var settingsRepoMock = new Mock<ISettingsRepository>();
      //   settingsRepoMock.Setup( sr => sr.GetExtensionColor( ".exe" ) ).Returns( exeColor );
      //   Dependency.RegisterInstance( settingsRepoMock.Object );

      //   // Test

      //   var fileController = new FileController();

      //   fileController.Run( new RunSettings() );

      //   // Assert

      //   consoleAdapterMock.Verify( ca => ca.WriteLine( fileName, ConsoleColor.Green ), Times.Once() );
      //}

      //[TestMethod]
      //public void Run_HasFileLength_LengthIsWrittenToConsole()
      //{
      //   var fileEntry = new FileEntry
      //   {
      //      FullName = "SomeFile.txt",
      //      Length = 123456789
      //   };

      //   string expectedLengthString = SizeFormatter.GetSizeString( fileEntry.Length ) + " ";

      //   // Setup

      //   var fileSystemMock = new Mock<IFileSystem>();
      //   fileSystemMock.Setup( fs => fs.GetFiles( It.IsAny<string>() ) ).Returns( fileEntry.AsArray() );
      //   Dependency.RegisterInstance( fileSystemMock.Object );

      //   var settingsRepoMock = new Mock<ISettingsRepository>();
      //   Dependency.RegisterInstance( settingsRepoMock.Object );

      //   var consoleAdapterMock = new Mock<IConsoleAdapter>();
      //   Dependency.RegisterInstance( consoleAdapterMock.Object );

      //   // Test

      //   var fileController = new FileController();

      //   fileController.Run( new RunSettings() );

      //   // Assert

      //   consoleAdapterMock.Verify( ca => ca.Write( expectedLengthString ), Times.Once() );
      //}
   }
}
