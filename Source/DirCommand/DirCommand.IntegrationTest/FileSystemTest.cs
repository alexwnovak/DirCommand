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
      public void GetFiles_DirectoryIsEmpty_ReturnsZeroFiles()
      {
         // Setup

         string tempDirectory = IntegrationHelper.CreateTempDirectory();
         
         // Test

         var fileSystem = new FileSystem();

         var files = fileSystem.GetFiles( tempDirectory );

         Assert.AreEqual( 0, files.Length );
      }
   }
}
