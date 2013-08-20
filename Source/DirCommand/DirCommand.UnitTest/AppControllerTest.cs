using Microsoft.VisualStudio.TestTools.UnitTesting;

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
      public void Run_ArgumentsIsNull_()
      {
      }
   }
}
