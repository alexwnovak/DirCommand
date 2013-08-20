using System.IO;

namespace DirCommand
{
   public class FileSystem : IFileSystem
   {
      public string[] GetFiles()
      {
         return Directory.GetFiles( "." );
      }
   }
}
