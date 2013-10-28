using System;
using System.Collections.Generic;

namespace DirCommand
{
   public static class SizeFormatter
   {
      private static readonly List<Tuple<long, string>> _metricGroups = GetMetricGroups();

      private static List<Tuple<long, string>> GetMetricGroups()
      {
         var metricGroups = new List<Tuple<long, string>>
         {
            new Tuple<long, string>( 1000000000000000000, "EB" ),
            new Tuple<long, string>( 1000000000000000, "PB" ),
            new Tuple<long, string>( 1000000000000, "TB" ),
            new Tuple<long, string>( 1000000000, "GB" ),
            new Tuple<long, string>( 1000000, "MB" ),
            new Tuple<long, string>( 1000, "KB" ),
            new Tuple<long, string>( 1, "B " )
         };

         return metricGroups;
      }

      public static string GetSizeString( long bytes )
      {
         if ( bytes < 0 )
         {
            throw new ArgumentException( "Size in bytes must not be negative" );
         }

         string sizeString = "  0";
         string postfix = "B ";

         foreach ( var tuple in _metricGroups )
         {
            if ( bytes >= tuple.Item1 )
            {
               sizeString = GetPaddedIntegerString( bytes / tuple.Item1 );

               postfix = tuple.Item2;

               break;
            }
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
