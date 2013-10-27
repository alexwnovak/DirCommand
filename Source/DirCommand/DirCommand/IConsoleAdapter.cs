using System;

namespace DirCommand
{
   public interface IConsoleAdapter
   {
      void Write( object obj );

      void WriteLine( string text );

      void WriteLine( string text, ConsoleColor foregroundColor );
   }
}
