using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DirCommand.UnitTest
{
   [TestClass]
   public class SizeFormatterTest
   {
      [TestMethod]
      public void GetSizeString_PassesZero_ReturnsCorrectString()
      {
         string sizeString = SizeFormatter.GetSizeString( 0 );

         Assert.AreEqual( sizeString, "  0 B " );
      }
   }
}
