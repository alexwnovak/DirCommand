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
   }
}
