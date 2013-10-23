using System;
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

      [TestMethod]
      public void Parse_PassesStringArgumentForPath_UsesSpecificPath()
      {
         var arguments = new[]
         {
            "SomeDirectory"
         };

         var argumentParser = new ArgumentParser();

         var runSettings = argumentParser.Parse( arguments );

         Assert.AreEqual( runSettings.Path, arguments[0] );
      }

      [TestMethod]
      public void Parse_PassesTwoStringArgumentsAsPath_UsesTheSecondAsPath()
      {
         var arguments = new[]
         {
            "FirstArgument",
            "SecondArgument"
         };

         var argumentParser = new ArgumentParser();

         var runSettings = argumentParser.Parse( arguments );

         Assert.AreEqual( runSettings.Path, arguments[1] );
      }

      [TestMethod]
      public void Parse_PassesRecursionFlag_EnablesRecursion()
      {
         var arguments = new[]
         {
            "/r"
         };

         var argumentParser = new ArgumentParser();

         var runSettings = argumentParser.Parse( arguments );

         Assert.IsTrue( runSettings.RecurseSubdirectories );
      }

      [TestMethod]
      public void Parse_PassesRecursionFlagWithCapitalLetter_EnablesRecursion()
      {
         var arguments = new[]
         {
            "/R"
         };

         var argumentParser = new ArgumentParser();

         var runSettings = argumentParser.Parse( arguments );

         Assert.IsTrue( runSettings.RecurseSubdirectories );
      }

      [TestMethod]
      public void Parse_PassesNonPathArgument_PathIsNotChanged()
      {
         var arguments = new[]
         {
            "/r"
         };

         var argumentParser = new ArgumentParser();

         var runSettings = argumentParser.Parse( arguments );

         Assert.AreEqual( RunSettings.DefaultPath, runSettings.Path );
      }

      [TestMethod]
      [ExpectedException( typeof( ArgumentException ) )]
      public void Parse_PassesUnrecognizedParamer_ThrowsArgumentException()
      {
         var arguments = new[]
         {
            "/somethingUnrecognized"
         };

         var argumentParser = new ArgumentParser();

         argumentParser.Parse( arguments );
      }

      [TestMethod]
      [ExpectedException( typeof ( ArgumentException ) )]
      public void Parse_PassesFilePathAndUnrecognizedParameter_ThrowsArgumentException()
      {
         var arguments = new[]
         {
            "somePath",
            "/somethingUnrecognized"
         };

         var argumentParser = new ArgumentParser();

         argumentParser.Parse( arguments );
      }

      [TestMethod]
      [ExpectedException( typeof( ArgumentException ) )]
      public void Parse_PassesFilePathAndUnrecognizedParameterInReverseOrder_ThrowsArgumentException()
      {
         var arguments = new[]
         {
            "/somethingUnrecognized",
            "somePath"
         };

         var argumentParser = new ArgumentParser();

         argumentParser.Parse( arguments );
      }

      [TestMethod]
      public void Parse_DoesNotPowerLowercaseFlag_LowercaseDisplayIsDisabledByDefault()
      {
         var argumentParser = new ArgumentParser();

         var runSettings = argumentParser.Parse( null );

         Assert.IsFalse( runSettings.DisplayAsLowercase );
      }

      [TestMethod]
      public void Parse_PassesLowercaseFlag_EnablesLowercaseDisplay()
      {
         var arguments = new[]
         {
            "/l"
         };

         var argumentParser = new ArgumentParser();

         var runSettings = argumentParser.Parse( arguments );

         Assert.IsTrue( runSettings.DisplayAsLowercase );
      }

      [TestMethod]
      public void Parse_PassesLowercaseFlagAsUppercase_EnablesLowercaseDisplay()
      {
         var arguments = new[]
         {
            "/L"
         };

         var argumentParser = new ArgumentParser();

         var runSettings = argumentParser.Parse( arguments );

         Assert.IsTrue( runSettings.DisplayAsLowercase );  
      }
   }
}
