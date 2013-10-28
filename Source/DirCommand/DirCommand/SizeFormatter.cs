﻿using System;

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

         if ( bytes < 0 )
         {
            throw new ArgumentException( "Size in bytes must not be negative" );
         }

         if ( bytes >= _exabytes )
         {
            sizeString = (bytes / _exabytes).ToString();
            
            sizeString = sizeString.PadLeft( 4 - sizeString.Length );

            return sizeString + " EB";
         }

         if ( bytes >= _petabytes )
         {
            return bytes / _petabytes + " PB";
         }

         if ( bytes >= _terabytes )
         {
            return bytes / _terabytes + " TB";
         }

         if ( bytes >= _gigabytes )
         {
            return bytes / _gigabytes + " GB";
         }

         if ( bytes >= _megabytes )
         {
            return bytes / _megabytes + " MB";
         }
         
         if ( bytes >= _kilobytes )
         {
            return bytes / _kilobytes + " KB";
         }

         return GetPaddedIntegerString( bytes ) + " B ";
      }

      private static string GetPaddedIntegerString( long integer )
      {
         string integerString = integer.ToString();

         return integerString.PadLeft( 3 );
      }
   }
}
