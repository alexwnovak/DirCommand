using System;

namespace DirCommand
{
   public class ConsoleAdapter : IConsoleAdapter
   {
      public void WriteLine( string text )
      {
         Console.WriteLine( text );
      }
   }
}
