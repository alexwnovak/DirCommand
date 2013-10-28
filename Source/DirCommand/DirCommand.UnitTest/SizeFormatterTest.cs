using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DirCommand.UnitTest
{
   [TestClass]
   public class SizeFormatterTest
   {
      [TestMethod]
      [ExpectedException( typeof( ArgumentException ) )]
      public void GetSizeString_PassesNegativeSize_ThrowsArgumentException()
      {
         SizeFormatter.GetSizeString( -1 );
      }

      [TestMethod]
      public void GetSizeString_PassesZero_ReturnsCorrectString()
      {
         string sizeString = SizeFormatter.GetSizeString( 0 );

         Assert.AreEqual( "  0 B ", sizeString );
      }

      [TestMethod]
      public void GetSizeString_SizeIs15Bytes_ReturnsCorrectString()
      {
         string sizeString = SizeFormatter.GetSizeString( 15 );

         Assert.AreEqual( " 15 B ", sizeString );
      }

      [TestMethod]
      public void GetSizeString_SizeIs290Bytes_ReturnsCorrectString()
      {
         string sizeString = SizeFormatter.GetSizeString( 290 );

         Assert.AreEqual( "290 B ", sizeString );
      }

      [TestMethod]
      public void GetSizeString_SizeIs5Kilobytes_ReturnsCorrectStringAndTruncatesDigits()
      {
         string sizeString = SizeFormatter.GetSizeString( 5123 );

         Assert.AreEqual( "  5 KB", sizeString );
      }

      [TestMethod]
      public void GetSizeString_SizeIs23Kilobytes_ReturnsCorrectStringAndTruncatesDigits()
      {
         string sizeString = SizeFormatter.GetSizeString( 23567 );

         Assert.AreEqual( " 23 KB", sizeString );
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

      [TestMethod]
      public void GetSizeString_SizeIs456Terabytes_ReturnsCorrectString()
      {
         string sizeString = SizeFormatter.GetSizeString( 456000000000000 );

         Assert.AreEqual( "456 TB", sizeString );
      }

      [TestMethod]
      public void GetSizeString_SizeIs567Petabytes_ReturnsCorrectString()
      {
         string sizeString = SizeFormatter.GetSizeString( 567000000000000000 );

         Assert.AreEqual( "567 PB", sizeString );
      }

      [TestMethod]
      public void GetSizeString_SizeIs9Exabytes_ReturnsCorrectString()
      {
         string sizeString = SizeFormatter.GetSizeString( 9000000000000000000 );

         Assert.AreEqual( "  9 EB", sizeString );
      }
   }
}
