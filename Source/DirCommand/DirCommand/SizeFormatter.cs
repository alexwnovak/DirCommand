using System;

namespace DirCommand
{
   public static class SizeFormatter
   {
      private const long _kilobytes = 1000;

      public static string GetSizeString( long bytes )
      {
         if ( bytes < 0 )
         {
            throw new ArgumentException( "Size in bytes must not be negative" );
         }
         else if ( bytes >= _kilobytes )
         {
            return bytes / _kilobytes + " KB";
         }


         return "  0 B ";
      }
   }
}
