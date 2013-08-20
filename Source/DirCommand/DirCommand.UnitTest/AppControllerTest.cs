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
      public void Run_ArgumentsIsNull_DisplaysSyntax()
      {
         // Setup

         var outputGuyMock = new Mock<IOutputGuy>();
         Dependency.RegisterInstance( outputGuyMock.Object );

         // Test

         var appController = new AppController();

         appController.Run( null );

         // Verify

         outputGuyMock.Verify( ogm => ogm.Syntax(), Times.Once() );
      }

      [TestMethod]
      public void Run_ArgumentsArrayIsEmpty_DisplaysSyntax()
      {
         // Setup

         var outputGuyMock = new Mock<IOutputGuy>();
         Dependency.RegisterInstance( outputGuyMock.Object );

         // Test

         var appController = new AppController();

         appController.Run( new string[0] );

         // Verify

         outputGuyMock.Verify( ogm => ogm.Syntax(), Times.Once() );
      }
   }
}
