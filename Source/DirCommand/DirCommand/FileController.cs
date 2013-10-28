using System;
using System.IO;

namespace DirCommand
{
   public class FileController : IFileController
   {
      public void Run( RunSettings runSettings )
      {
         var fileSystem = Dependency.Resolve<IFileSystem>();

         var files = fileSystem.GetFiles( runSettings.Path );

         var settingsRepository = Dependency.Resolve<ISettingsRepository>();

         var consoleAdapter = Dependency.Resolve<IConsoleAdapter>();

         foreach ( var file in files )
         {
            string sizeString = SizeFormatter.GetSizeString( file.Length );

            consoleAdapter.Write( sizeString + " " );

            string extension = Path.GetExtension( file.FullName ).ToLower();

            ConsoleColor color = settingsRepository.GetExtensionColor( extension );

            consoleAdapter.WriteLine( file.FullName, color );
         }
      }
   }
}
