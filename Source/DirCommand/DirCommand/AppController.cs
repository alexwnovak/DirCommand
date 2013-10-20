namespace DirCommand
{
   public class AppController
   {
      public void Run( string[] arguments )
      {
         var displayController = Dependency.Resolve<IDisplayController>();

         if ( arguments == null || arguments.Length == 0 )
         {
            displayController.ShowSyntax();
            return;
         }

         var fileSystem = Dependency.Resolve<IFileSystem>();

         var files = fileSystem.GetFiles( "." );

         displayController.Display( files );
      }
   }
}
