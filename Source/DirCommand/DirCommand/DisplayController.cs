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

         consoleAdapter.WriteLine( DisplayFrame.GetTopHeader(), ConsoleColor.DarkGray );

         string fullDirectoryPath = Path.GetFullPath( runSettings.Path );
         consoleAdapter.WriteLine( fullDirectoryPath );

         consoleAdapter.WriteLine( DisplayFrame.GetBottomHeader(), ConsoleColor.DarkGray );

         foreach ( var file in files )
         {
            if ( file.IsDirectory )
            {
               consoleAdapter.Write( "Folder", ConsoleColor.Magenta );

               consoleAdapter.Write( string.Format( " {0} ", DisplayFrame.PipeCharacter ), ConsoleColor.DarkGray );

               consoleAdapter.Write( Path.GetFileName( file.FullName ), ConsoleColor.Magenta );

               int filePaneWidth = (consoleAdapter.GetWindowWidth() - 2) / 2 - 7;

               var padding = new string( ' ', filePaneWidth - file.FullName.Length );

               consoleAdapter.WriteLine( padding + "| " );
            }
            else
            {
               DisplayFrame.WriteFile( file );
            }
         }

         consoleAdapter.WriteLine( DisplayFrame.GetFooter(), ConsoleColor.DarkGray );
      }

      public void ShowError( string message )
      {
         throw new System.NotImplementedException();
      }
   }
}
