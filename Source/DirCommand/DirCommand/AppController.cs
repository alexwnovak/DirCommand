using System;

namespace DirCommand
{
   public class AppController
   {
      public int Run( string[] arguments )
      {
         // Parse the arguments

         var argumentParser = Dependency.Resolve<IArgumentParser>();
         RunSettings runSettings;

         try
         {
            runSettings = argumentParser.Parse( arguments );
         }
         catch ( ArgumentException ex )
         {
            Dependency.Resolve<IDisplayController>().ShowError( ex.Message );
            return 1;
         }

         // Read files

         var fileSystem = Dependency.Resolve<IFileSystem>();

         var files = fileSystem.GetFiles( runSettings.Path );

         // Display

         var displayController = Dependency.Resolve<IDisplayController>();

         displayController.Display( files );

         return 0;
      }
   }
}
