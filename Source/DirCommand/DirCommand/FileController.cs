using System.IO;
using System.Linq;

namespace DirCommand
{
   public class FileController : IFileController
   {
      public string[] GetFiles( string path )
      {
         var fileSystem = Dependency.Resolve<IFileSystem>();

         var directories = fileSystem.GetDirectories( path ).Select( Path.GetFileName );

         var files = fileSystem.GetFiles( path ).Select( Path.GetFileName );

         return directories.Concat( files ).ToArray();
      }
   }
}
