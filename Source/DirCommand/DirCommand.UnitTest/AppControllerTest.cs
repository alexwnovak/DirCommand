using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DirCommand.UnitTest
{
   [TestClass]
   public class AppControllerTest
   {
      [TestMethod]
      public void Run_ArgumentsIsNull_DisplaysSyntax()
      {
         var appController = new AppController();

         appController.Run( null );
      }
   }
}
