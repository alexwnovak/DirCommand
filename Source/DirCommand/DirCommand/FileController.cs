namespace DirCommand
{
   public class FileController : IFileController
   {
      public void Run( RunSettings runSettings )
      {
         var fileSystem = Dependency.Resolve<IFileSystem>();

         var files = fileSystem.GetFiles( runSettings.Path );

         var displayController = Dependency.Resolve<IDisplayController>();

         displayController.Display( runSettings, files );
      }
   }
}
