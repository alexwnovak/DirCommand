using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DirCommand.UnitTest
{
   [TestClass]
   public class ArgumentParserTest
   {
      [TestMethod]
      public void Parse_NullArguments_UsesDefaultPath()
      {
         var argumentParser = new ArgumentParser();

         var runSettings = argumentParser.Parse( null );

         Assert.AreEqual( RunSettings.DefaultPath, runSettings.Path );
      }

      [TestMethod]
      public void Parse_EmptyArguments_UsesDefaultPath()
      {
         var argumentParser = new ArgumentParser();

         var runSettings = argumentParser.Parse( new string[0] );

         Assert.AreEqual( RunSettings.DefaultPath, runSettings.Path );
      }
   }
}
