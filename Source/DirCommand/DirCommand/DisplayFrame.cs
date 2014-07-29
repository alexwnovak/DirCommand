using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace DirCommand
{
   public static class DisplayFrame
   {
      private static readonly Encoding _encoding = Encoding.GetEncoding( 437 );
      private static readonly int _consoleWidth = GetConsoleWidth();

      public static char PipeCharacter
      {
         get
         {
            return AsciiCode( 179 );
         }
      }

      private static int GetConsoleWidth()
      {
         return 124;
      }

      public static string GetTopHeader()
      {
         return Repeat( 0xCD, _consoleWidth );
      }

      public static void WriteFile( FileEntry fileEntry )
      {
         int fileNameMaxLength = ( _consoleWidth - 2 ) / 2;

         var consoleAdapter = Dependency.Resolve<IConsoleAdapter>();
         var settingsRepository = Dependency.Resolve<ISettingsRepository>();

         string sizeString = SizeFormatter.GetSizeString( fileEntry.Length );

         consoleAdapter.Write( sizeString );

         consoleAdapter.Write( "  " );

         //consoleAdapter.Write( string.Format( " {0} ", DisplayFrame.PipeCharacter ), ConsoleColor.DarkGray );

         fileEntry.FullName = new string( 'F', 51 );

         string extension = Path.GetExtension( fileEntry.FullName ).ToLower();

         ConsoleColor color = settingsRepository.GetExtensionColor( extension );

         consoleAdapter.Write( Path.GetFileName( fileEntry.FullName ), color );

         //int filePaneWidth = (consoleAdapter.GetWindowWidth() - 2) / 2 - 9;

         //var padding = new string( ' ', filePaneWidth - fileEntry.FullName.Length );

         //consoleAdapter.WriteLine( padding + "| " );

         consoleAdapter.Write( "    " );

         consoleAdapter.WriteLine( sizeString + "  " + fileEntry.FullName );
      }

      public static string GetBottomHeader()
      {
         // 9 for everything before the file name

         // +3 for space, separator, space

         // +9 for second column

         // First half: ( Width / 2 ) - 9 - 2

         int paneWidth = (_consoleWidth - 2) / 2;

         // Left pane

         var stringBuilder = new StringBuilder();

         stringBuilder.Append( Repeat( 0xCD, paneWidth ) );

         // Pane separator

         stringBuilder.Append( "+-" );

         // Right pane

         stringBuilder.Append( Repeat( 0xCD, paneWidth ) );

         return stringBuilder.ToString();

         //int length1 = 7;
         //int length2 = _consoleWidth / 2 - 9 - 2;
         //int length3 = _consoleWidth / 2 - 9 - 2;

         //// Left pane

         //stringBuilder.Append( Repeat( 0xCD, length1 ) );
         //stringBuilder.Append( AsciiCode( 209 ) );
         //stringBuilder.Append( Repeat( 0xCD, length2 ) );

         //// Separator

         //stringBuilder.Append( AsciiCode( 203 ) );

         //// Right pane

         //stringBuilder.Append( Repeat( 0xCD, 8 ) );
         //stringBuilder.Append( AsciiCode( 209 ) );
         //stringBuilder.Append( Repeat( 0xCD, length3 ) );

         //return stringBuilder.ToString();


         //return string.Format( "{0}{1}{2}{3}{4}", Repeat( 0xCD, length1 ), c1, Repeat( 0xCD, length2 ), c2, Repeat( 0xCD, length3 ) );
      }

      public static string GetFooter()
      {
         return string.Format( "{0}{1}{2}", Repeat( 0xCD, 7 ), AsciiCode( 207 ), Repeat( 0xCD, _consoleWidth - 8 ) );
      }

      private static char AsciiCode( byte character )
      {
         return _encoding.GetString( new[]
         {
            character
         } )[0];
      }

      private static string Repeat( byte character, int length )
      {
         string byteString = _encoding.GetString( new[]
         {
            character
         } );

         var chars = Enumerable.Repeat( byteString[0], length ).ToArray();

         return new string( chars );
      }
   }
}
