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

            var files = GetFileEntries( runSettings );

            DisplayFileEntries( files );
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

      private static string[] GetFileEntries( RunSettings runSettings )
      {
         var fileSystem = Dependency.Resolve<IFileSystem>();

         return fileSystem.GetFiles( runSettings.Path );
      }

      private static void DisplayFileEntries( string[] files )
      {
         var displayController = Dependency.Resolve<IDisplayController>();

         displayController.Display( files );
      }
   }
}
