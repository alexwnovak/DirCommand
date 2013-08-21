using System.IO;
using System.Linq;

namespace DirCommand
{
   public class FileSystem : IFileSystem
   {
      public string[] GetFiles( string path )
      {
         return Directory.GetFiles( path ).Select( Path.GetFileName ).ToArray();
      }
   }
}
