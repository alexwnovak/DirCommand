using System.IO;
using System.Linq;

namespace DirCommand
{
   public class FileController : IFileController
   {
      public FileEntry[] GetFiles( string path )
      {
         return new FileEntry[0];

         //var fileSystem = Dependency.Resolve<IFileSystem>();

         //var directories = fileSystem.GetDirectories( path ).Select( Path.GetFileName );

         //var files = fileSystem.GetFiles( path ).Select( Path.GetFileName );

         //return directories.Concat( files ).ToArray();
      }
   }
}
