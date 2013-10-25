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
      public void GetFiles_HappyPath_ReturnsEmptyArray()
      {
         // Setup

         var fileSystemMock = new Mock<IFileSystem>();
         Dependency.RegisterInstance( fileSystemMock.Object );

         // Test

         var fileController = new FileController();

         var files = fileController.GetFiles( "." );

         Assert.AreEqual( 0, files.Length );
      }

      [TestMethod]
      public void GetFiles_FileSystemHasOneFile_ReturnsTheOneFile()
      {
         const string fileName = @"C:\SomeFile.txt";
         const string path = "SomePath";

         // Setup

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.GetFiles( It.IsAny<string>() ) ).Returns( fileName.AsArray() ); 
         Dependency.RegisterInstance( fileSystemMock.Object );

         // Test

         var fileController = new FileController();

         var files = fileController.GetFiles( path );

         // Assert

         Assert.AreEqual( 1, files.Length );
         Assert.AreEqual( fileName, files[0].FullName );
      }
   }
}
