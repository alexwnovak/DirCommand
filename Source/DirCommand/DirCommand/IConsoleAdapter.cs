using System;

namespace DirCommand
{
   public interface IConsoleAdapter
   {
      void WriteLine( string text );

      void WriteLine( string text, ConsoleColor foregroundColor );
   }
}
