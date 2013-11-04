using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DirCommand.IntegrationTest
{
   [TestClass]
   public class FileSystemTest
   {
      [TestInitialize]
      public void Initialize()
      {
         IntegrationHelper.DeleteTempDirectory();
      }

      [TestMethod]
      [TestCategory( "Integration" )]
      public void GetFiles_DirectoryIsEmpty_ReturnsZeroFiles()
      {
         // Setup

         string tempDirectory = IntegrationHelper.CreateTempDirectory();

         // Test

         var fileSystem = new FileSystem();

         var files = fileSystem.GetFiles( tempDirectory );

         Assert.AreEqual( 0, files.Count() );
      }

      [TestMethod]
      [TestCategory( "Integration" )]
      public void GetFiles_DirectoryHasOneFile_ReturnsTheOneFile()
      {
         // Setup

         string tempDirectory = IntegrationHelper.CreateTempDirectory();
         string fileName = IntegrationHelper.CreateTempFile( tempDirectory );

         // Test

         var fileSystem = new FileSystem();

         var files = fileSystem.GetFiles( tempDirectory );

         Assert.AreEqual( 1, files.Count() );
         Assert.AreEqual( fileName, files.First().FullName );
      }

      [TestMethod]
      [TestCategory( "Integration" )]
      public void GetFiles_DirectoryHasOneFileAndOneSubDirectory_ReturnsAll()
      {
         // Setup

         string tempDirectory = IntegrationHelper.CreateTempDirectory();
         string subDirectory = IntegrationHelper.CreateSubDirectory( tempDirectory );
         string fileName = IntegrationHelper.CreateTempFile( tempDirectory );

         string fullDirectoryPath = Path.Combine( tempDirectory, subDirectory );
         string fullPath = Path.Combine( tempDirectory, subDirectory, fileName );

         // Test

         var fileSystem = new FileSystem();

         var files = fileSystem.GetFiles( tempDirectory );

         Assert.AreEqual( 2, files.Count() );
         Assert.AreEqual( fullDirectoryPath, files.First().FullName );
         Assert.AreEqual( fullPath, files.ElementAt( 1 ).FullName );
      }

      [TestMethod]
      [TestCategory( "Integration" )]
      public void GetFiles_DirectoryHasOneFile_ReturnsFileSize()
      {
         const int fileSize = 12;

         // Setup

         string tempDirectory = IntegrationHelper.CreateTempDirectory();
         IntegrationHelper.CreateTempFile( tempDirectory, fileSize );

         // Test

         var fileSystem = new FileSystem();

         var files = fileSystem.GetFiles( tempDirectory );

         // Assert

         Assert.AreEqual( fileSize, files[0].Length );
      }

      [TestMethod]
      public void GetFiles_HasDirectory_ReturnsDirectoryFlagSet()
      {
         // Setup

         string tempDirectory = IntegrationHelper.CreateTempDirectory();
         const string subDirectory = "OneSubDirectory";
         string fullPath = Path.Combine( tempDirectory, subDirectory );
         Directory.CreateDirectory( fullPath );

         // Test

         var fileSystem = new FileSystem();

         var files = fileSystem.GetFiles( tempDirectory );

         // Assert

         Assert.AreEqual( 1, files.Length );
         Assert.AreEqual( fullPath, files[0].FullName );
         Assert.IsTrue( files[0].IsDirectory );
      }
   }
}
