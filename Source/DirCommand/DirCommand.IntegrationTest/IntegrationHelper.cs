using System;
using System.IO;

namespace DirCommand.IntegrationTest
{
   public static class IntegrationHelper
   {
      private const string _testDirectoryName = "DirCommand_IntegrationTest";

      public static string CreateTempDirectory()
      {
         string tempPath = Path.GetTempPath();
         string testDirectory = Path.Combine( tempPath, _testDirectoryName );
         string runDirectory = GetRunDirectoryName() + GetNextIndex( testDirectory );
         
         string finalPath = Path.Combine( tempPath, _testDirectoryName, runDirectory );

         Directory.CreateDirectory( finalPath );

         return finalPath;
      }

      private static string GetRunDirectoryName()
      {
         return DateTime.Now.ToString( "yyyy-MM-d" ) + "_Run";
      }

      private static int GetNextIndex( string path )
      {
         string thisDirectory;
         int index = 0;

         do
         {
            index++;
            thisDirectory = GetRunDirectoryName() + index;
         }
         while ( Directory.Exists( Path.Combine( path, thisDirectory ) ) );

         return index;
      }

      public static void CreateDirectory( string tempDirectory, string directoryName )
      {
         string fullPath = Path.Combine( tempDirectory, directoryName );

         Directory.CreateDirectory( fullPath );
      }

      public static void DeleteTempDirectory()
      {
         string tempPath = Path.GetTempPath();

         string testDirectory = Path.Combine( tempPath, _testDirectoryName );

         try
         {
            Directory.Delete( testDirectory, true );
         }
         catch ( DirectoryNotFoundException )
         {
            // It's OK to eat this exception. Attempting to delete an already-deleted item counts as
            // a "no op," since we got what we want: the directory is gone
         }
      }
   }
}
