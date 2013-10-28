using System;

namespace DirCommand
{
   public static class SizeFormatter
   {
      public static string GetSizeString( long bytes )
      {
         if ( bytes < 0 )
         {
            throw new ArgumentException( "Size in bytes must not be negative" );
         }

         return "  0 B ";
      }
   }
}
