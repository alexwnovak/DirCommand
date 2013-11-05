using System;
using System.IO;

namespace DirCommand
{
   public class DisplayController : IDisplayController
   {
      public void Display( RunSettings runSettings, FileEntry[] files )
      {
         var settingsRepository = Dependency.Resolve<ISettingsRepository>();

         var consoleAdapter = Dependency.Resolve<IConsoleAdapter>();

         foreach ( var file in files )
         {
            if ( file.IsDirectory )
            {
               consoleAdapter.Write( "Folder", ConsoleColor.Magenta );

               consoleAdapter.Write( " | ", ConsoleColor.DarkGray );

               consoleAdapter.WriteLine( Path.GetFileName( file.FullName ), ConsoleColor.Magenta );
            }
            else
            {
               string sizeString = SizeFormatter.GetSizeString( file.Length );

               consoleAdapter.Write( sizeString );

               consoleAdapter.Write( " | ", ConsoleColor.DarkGray );

               string extension = Path.GetExtension( file.FullName ).ToLower();

               ConsoleColor color = settingsRepository.GetExtensionColor( extension );

               consoleAdapter.WriteLine( Path.GetFileName( file.FullName ), color );               
            }
         }
      }

      public void ShowError( string message )
      {
         throw new System.NotImplementedException();
      }
   }
}
