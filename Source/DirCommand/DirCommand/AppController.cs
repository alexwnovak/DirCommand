namespace DirCommand
{
   public class AppController
   {
      public void Run( string[] arguments )
      {
         // Parse the arguments

         var argumentParser = Dependency.Resolve<IArgumentParser>();

         argumentParser.Parse( arguments );

         // Read files

         var fileSystem = Dependency.Resolve<IFileSystem>();

         var files = fileSystem.GetFiles( "." );

         // Display

         var displayController = Dependency.Resolve<IDisplayController>();

         displayController.Display( files );
      }
   }
}
