using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DirCommand.UnitTest
{
   [TestClass]
   public class SettingsRepositoryTest
   {
      [TestMethod]
      public void GetExtensionColor_ExtensionIsNotMapped_ReturnsGrayAsDefault()
      {
         var settingsRepository = new SettingsRepository();

         var consoleColor = settingsRepository.GetExtensionColor( ".DoesNotHaveOne" );

         Assert.AreEqual( ConsoleColor.Gray, consoleColor );
      }
   }
}
