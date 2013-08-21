using System.IO;
using System.Linq;

namespace DirCommand
{
   public class FileSystem : IFileSystem
   {
      public string[] GetFiles( string path )
      {
         var directories = Directory.GetDirectories( path ).Select( Path.GetFileName );

         var files = Directory.GetFiles( path ).Select( Path.GetFileName );

         return directories.Concat( files ).ToArray();
      }
   }
}
