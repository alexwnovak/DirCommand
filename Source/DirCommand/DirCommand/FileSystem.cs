using System.Collections.Generic;
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
         var fileEntries = new List<FileEntry>();

         var directories = Directory.GetDirectories( path );

         foreach ( var directory in directories )
         {
            var fileEntry = new FileEntry
            {
               FullName = directory,
               IsDirectory = true
            };

            fileEntries.Add( fileEntry );
         }

         var files = Directory.GetFiles( path );

         foreach ( var file in files )
         {
            var fileInfo = new FileInfo( file );

            var fileEntry = new FileEntry
            {
               FullName = file,
               Length = fileInfo.Length
            };

            fileEntries.Add( fileEntry );
         }

         return fileEntries.ToArray();
      }
   }
}
