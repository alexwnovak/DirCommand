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

      [TestMethod]
      public void Constructor_PassesUppercaseArgument_StoresArgumentAsLowercase()
      {
         const string argument = "UppercaseArgument";

         var argumentHandlerAttribute = new ArgumentHandlerAttribute( argument );

         Assert.AreEqual( argument.ToLower(), argumentHandlerAttribute.Argument );  
      }
   }
}
