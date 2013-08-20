namespace DirCommand
{
   public class AppController
   {
      public void Run( string[] arguments )
      {
         var fileSystem = Dependency.Resolve<IFileSystem>();

         fileSystem.GetFiles();
      }
   }
}
