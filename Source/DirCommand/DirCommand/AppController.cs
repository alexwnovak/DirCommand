namespace DirCommand
{
   public class AppController
   {
      public void Run( string[] arguments )
      {
         var fileSystem = Dependency.Resolve<IFileSystem>();

         var files = fileSystem.GetFiles( "." );

         var displayController = Dependency.Resolve<IDisplayController>();

         displayController.Display( files );
      }
   }
}
