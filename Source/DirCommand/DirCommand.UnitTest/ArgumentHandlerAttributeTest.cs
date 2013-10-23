using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DirCommand.UnitTest
{
   [TestClass]
   public class ArgumentHandlerAttributeTest
   {
      [TestMethod]
      public void Constructor_PassesArgument_StoresArgument()
      {
         const string argument = "arg";

         var argumentHandlerAttribute = new ArgumentHandlerAttribute( argument );

         Assert.AreEqual( argument, argumentHandlerAttribute.Argument );
      }
   }
}
