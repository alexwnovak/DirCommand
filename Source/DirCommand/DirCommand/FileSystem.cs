using System.IO;

namespace DirCommand
{
   public class FileSystem : IFileSystem
   {
      public string[] GetFiles( string path )
      {
         return Directory.GetFiles( path );
      }
   }
}
