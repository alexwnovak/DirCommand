using System;
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

         Assert.AreEqual( "  0 B ", sizeString );
      }

      [TestMethod]
      [ExpectedException( typeof( ArgumentException ) )]
      public void GetSizeString_PassesNegativeSize_ThrowsArgumentException()
      {
         SizeFormatter.GetSizeString( -1 );
      }

      [TestMethod]
      public void GetSizeString_SizeIs123Kilobytes_ReturnsCorrectString()
      {
         string sizeString = SizeFormatter.GetSizeString( 123000 );

         Assert.AreEqual( "123 KB", sizeString );
      }

      [TestMethod]
      public void GetSizeString_SizeIs234Megabytes_ReturnsCorrectString()
      {
         string sizeString = SizeFormatter.GetSizeString( 234000000 );

         Assert.AreEqual( "234 MB", sizeString );
      }

      [TestMethod]
      public void GetSizeString_SizeIs345Gigabytes_ReturnsCorrectString()
      {
         string sizeString = SizeFormatter.GetSizeString( 345000000000 );

         Assert.AreEqual( "345 GB", sizeString );
      }
   }
}
