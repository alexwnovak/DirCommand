using System;

namespace DirCommand
{
   public static class SizeFormatter
   {
      private const long _kilobytes = 1000;
      private const long _megabytes = 1000000;

      public static string GetSizeString( long bytes )
      {
         if ( bytes < 0 )
         {
            throw new ArgumentException( "Size in bytes must not be negative" );
         }

         if ( bytes >= _megabytes )
         {
            return bytes / _megabytes + " MB";
         }
         
         if ( bytes >= _kilobytes )
         {
            return bytes / _kilobytes + " KB";
         }

         return "  0 B ";
      }
   }
}
