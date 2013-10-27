using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;

namespace DirCommand
{
   public class FileController : IFileController
   {
      //public FileEntry[] GetFiles( string path )
      //{
      //   //var fileSystem = Dependency.Resolve<IFileSystem>();

      //   //return fileSystem.GetFiles( path ).Select( f => new FileEntry
      //   //{
      //   //   FullName = f
      //   //}).ToArray();

      //   //var fileSystem = Dependency.Resolve<IFileSystem>();

      //   //var directories = fileSystem.GetDirectories( path ).Select( Path.GetFileName );

      //   //var files = fileSystem.GetFiles( path ).Select( Path.GetFileName );

      //   //return directories.Concat( files ).ToArray();
      //}

      public void Run( RunSettings runSettings )
      {
         var fileSystem = Dependency.Resolve<IFileSystem>();

         var files = fileSystem.GetFiles( runSettings.Path );

         var settingsRepository = Dependency.Resolve<ISettingsRepository>();

         var consoleAdapter = Dependency.Resolve<IConsoleAdapter>();

         foreach ( string file in files )
         {
            string extension = Path.GetExtension( file );

            ConsoleColor color = settingsRepository.GetExtensionColor( extension );

            consoleAdapter.WriteLine( file, color );
         }
      }
   }
}
