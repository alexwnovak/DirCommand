using System;

namespace DirCommand
{
   public class ConsoleAdapter : IConsoleAdapter
   {
      public void WriteLine( string text )
      {
         Console.WriteLine( text );
      }

      public void WriteLine( string text, ConsoleColor foregroundColor )
      {
         var oldForegroundColor = Console.ForegroundColor;

         Console.ForegroundColor = foregroundColor;

         Console.WriteLine( text );

         Console.ForegroundColor = oldForegroundColor;
      }
   }
}
