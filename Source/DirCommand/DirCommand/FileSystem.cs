using System;
using System.IO;

namespace DirCommand
{
   public class FileSystem : IFileSystem
   {
      public string[] GetDirectories( string path )
      {
         return Directory.GetDirectories( path );
      }

      public FileEntry[] GetFiles( string path )
      {
         throw new NotImplementedException();

         //var directories = Directory.GetDirectories( path ).Select( Path.GetFileName );

         //var files = Directory.GetFiles( path ).Select( Path.GetFileName );

         //return directories.Concat( files ).ToArray();
      }
   }
}
