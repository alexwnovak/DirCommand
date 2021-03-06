﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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
      public void Run_ArgumentsIsNull_FileControllerRunsWithRunSettings()
      {
         var runSettings = new RunSettings();

         // Setup

         var fileControllerMock = new Mock<IFileController>();
         Dependency.RegisterInstance( fileControllerMock.Object );

         var displayControllerMock = new Mock<IDisplayController>();
         Dependency.RegisterInstance( displayControllerMock.Object );

         var argumentParserMock = new Mock<IArgumentParser>();
         argumentParserMock.Setup( ap => ap.Parse( It.IsAny<string[]>() ) ).Returns( runSettings );
         Dependency.RegisterInstance( argumentParserMock.Object );

         // Test

         var appController = new AppController();

         appController.Run( new string[1] );

         // Verify

         fileControllerMock.Verify( fc => fc.Run( runSettings ), Times.Once() );
      }

      [TestMethod]
      public void Run_HappyPath_ReturnsExitCodeZero()
      {
         // Setup

         var fileSystemMock = new Mock<IFileController>();
         Dependency.RegisterInstance( fileSystemMock.Object );

         var displayControllerMock = new Mock<IDisplayController>();
         Dependency.RegisterInstance( displayControllerMock.Object );

         var argumentParserMock = new Mock<IArgumentParser>();
         argumentParserMock.Setup( ap => ap.Parse( It.IsAny<string[]>() ) ).Returns( new RunSettings() );
         Dependency.RegisterInstance( argumentParserMock.Object );

         // Test

         var appController = new AppController();

         int exitCode = appController.Run( null );

         Assert.AreEqual( 0, exitCode );
      }

      [TestMethod]
      public void Run_ArgumentsAreNull_NullArgumentsAreSentToParser()
      {
         // Setup

         var fileSystemMock = new Mock<IFileController>();
         Dependency.RegisterInstance( fileSystemMock.Object );

         var displayControllerMock = new Mock<IDisplayController>();
         Dependency.RegisterInstance( displayControllerMock.Object );

         var argumentParserMock = new Mock<IArgumentParser>();
         argumentParserMock.Setup( ap => ap.Parse( It.IsAny<string[]>() ) ).Returns( new RunSettings() );
         Dependency.RegisterInstance( argumentParserMock.Object );

         // Test

         var appController = new AppController();

         appController.Run( null );

         // Verify

         argumentParserMock.Verify( ap => ap.Parse( null ), Times.Once() );
      }

      [TestMethod]
      public void Run_HasArguments_ArgumentsAreSentToParser()
      {
         var arguments = new string[1];

         // Setup

         var fileSystemMock = new Mock<IFileController>();
         Dependency.RegisterInstance( fileSystemMock.Object );

         var displayControllerMock = new Mock<IDisplayController>();
         Dependency.RegisterInstance( displayControllerMock.Object );

         var argumentParserMock = new Mock<IArgumentParser>();
         argumentParserMock.Setup( ap => ap.Parse( It.IsAny<string[]>() ) ).Returns( new RunSettings() );
         Dependency.RegisterInstance( argumentParserMock.Object );

         // Test

         var appController = new AppController();

         appController.Run( arguments );

         // Verify

         argumentParserMock.Verify( ap => ap.Parse( arguments ), Times.Once() );
      }

      [TestMethod]
      public void Run_ArgumentParserEncountersUnrecognizedArgument_DisplaysErrorMessage()
      {
         const string errorMessage = "This is the error message";

         // Setup

         var argumentParserMock = new Mock<IArgumentParser>();
         argumentParserMock.Setup( ap => ap.Parse( It.IsAny<string[]>() ) ).Throws( new ArgumentException( errorMessage ) );
         Dependency.RegisterInstance( argumentParserMock.Object );

         var displayControllerMock = new Mock<IDisplayController>();
         Dependency.RegisterInstance( displayControllerMock.Object );

         // Test

         var appController = new AppController();

         appController.Run( null );

         // Assert

         displayControllerMock.Verify( dc => dc.ShowError( errorMessage ), Times.Once() );
      }

      [TestMethod]
      public void Run_ArgumentParserEncountersUnrecognizedArgument_ReturnsExitCodeOfOne()
      {
         const string errorMessage = "This is the error message";

         // Setup

         var argumentParserMock = new Mock<IArgumentParser>();
         argumentParserMock.Setup( ap => ap.Parse( It.IsAny<string[]>() ) ).Throws( new ArgumentException( errorMessage ) );
         Dependency.RegisterInstance( argumentParserMock.Object );

         var displayControllerMock = new Mock<IDisplayController>();
         Dependency.RegisterInstance( displayControllerMock.Object );

         // Test

         var appController = new AppController();

         int exitCode = appController.Run( null );

         Assert.AreEqual( 1, exitCode );
      }

      [TestMethod]
      public void Run_RunSettingsHasCustomPath_UsesDefaultPathWithFileSystem()
      {
         var runSettings = new RunSettings
         {
            Path = "SomePath"
         };

         // Setup

         var argumentParserMock = new Mock<IArgumentParser>();
         argumentParserMock.Setup( ap => ap.Parse( It.IsAny<string[]>() ) ).Returns( runSettings );
         Dependency.RegisterInstance( argumentParserMock.Object );

         var fileControllerMock = new Mock<IFileController>();
         Dependency.RegisterInstance( fileControllerMock.Object );

         var displayControllerMock = new Mock<IDisplayController>();
         Dependency.RegisterInstance( displayControllerMock.Object );

         // Test

         var appController = new AppController();

         appController.Run( null );

         // Assert

         fileControllerMock.Verify( fc => fc.Run( runSettings ), Times.Once() );
      }

      [TestMethod]
      public void Run_FileControllerFails_ReturnsExitCodeOne()
      {
         const int expectedExitCode = 123;

         // Setup

         var argumentParserMock = new Mock<IArgumentParser>();
         Dependency.RegisterInstance( argumentParserMock.Object );

         var fileControllerMock = new Mock<IFileController>();
         fileControllerMock.Setup( fc => fc.Run( It.IsAny<RunSettings>() ) ).Throws( new AbortProgramException( expectedExitCode ) );
         Dependency.RegisterInstance( fileControllerMock.Object );

         // Test

         var appController = new AppController();

         int actualExitCode = appController.Run( null );

         // Assert

         Assert.AreEqual( expectedExitCode, actualExitCode );
      }
   }
}
