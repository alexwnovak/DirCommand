using System;

namespace DirCommand
{
   public class AppController
   {
      public int Run( string[] arguments )
      {
         int exitCode = 0;

         try
         {
            var runSettings = GetRunSettings( arguments );

            // Read files

            var fileSystem = Dependency.Resolve<IFileSystem>();

            var files = fileSystem.GetFiles( runSettings.Path );

            // Display

            var displayController = Dependency.Resolve<IDisplayController>();

            displayController.Display( files );

         }
         catch ( AbortProgramException ex )
         {
            exitCode = ex.ExitCode;
         }

         return exitCode;
      }

      private static RunSettings GetRunSettings( string[] arguments )
      {
         var argumentParser = Dependency.Resolve<IArgumentParser>();

         try
         {
            return argumentParser.Parse( arguments );
         }
         catch ( ArgumentException ex )
         {
            Dependency.Resolve<IDisplayController>().ShowError( ex.Message );
            throw new AbortProgramException( 1 );
         }
      }
   }
}
