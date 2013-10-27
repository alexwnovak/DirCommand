using System;
using System.Collections.Generic;

namespace DirCommand
{
   public class SettingsRepository : ISettingsRepository
   {
      private readonly Dictionary<string, ConsoleColor> _extensionColors;

      public SettingsRepository()
      {
         _extensionColors = new Dictionary<string, ConsoleColor>();
         _extensionColors[".exe"] = ConsoleColor.Green;
      }

      public ConsoleColor GetExtensionColor( string extension )
      {
         ConsoleColor color;

         if ( _extensionColors.TryGetValue( extension, out color ) )
         {
            return color;
         }

         return ConsoleColor.Gray;
      }
   }
}
