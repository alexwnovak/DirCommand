using System;

namespace DirCommand
{
   public static class SizeFormatter
   {
      private const long _kilobytes = 1000;
      private const long _megabytes = 1000000;
      private const long _gigabytes = 1000000000;
      private const long _terabytes = 1000000000000;
      private const long _petabytes = 1000000000000000;
      private const long _exabytes = 1000000000000000000;

      public static string GetSizeString( long bytes )
      {
         string sizeString;
         string postfix;

         if ( bytes < 0 )
         {
            throw new ArgumentException( "Size in bytes must not be negative" );
         }

         if ( bytes >= _exabytes )
         {
            sizeString = GetPaddedIntegerString( bytes / _exabytes );
            postfix = "EB";
         }
         else if ( bytes >= _petabytes )
         {
            sizeString = GetPaddedIntegerString( bytes / _petabytes );
            postfix = "PB";
         }
         else if ( bytes >= _terabytes )
         {
            sizeString = GetPaddedIntegerString( bytes / _terabytes );
            postfix = "TB";
         }
         else if ( bytes >= _gigabytes )
         {
            sizeString = GetPaddedIntegerString( bytes / _gigabytes );
            postfix = "GB";
         }
         else if ( bytes >= _megabytes )
         {
            sizeString = GetPaddedIntegerString( bytes / _megabytes );
            postfix = "MB";
         }
         else if ( bytes >= _kilobytes )
         {
            sizeString = GetPaddedIntegerString( bytes / _kilobytes );
            postfix = "KB";
         }
         else
         {
            sizeString = GetPaddedIntegerString( bytes );
            postfix = "B ";
         }

         return string.Format( "{0} {1}", sizeString, postfix );
      }

      private static string GetPaddedIntegerString( long integer )
      {
         string integerString = integer.ToString();

         return integerString.PadLeft( 3 );
      }
   }
}
