using System;

namespace DirCommand
{
   public class SettingsRepository : ISettingsRepository
   {
      public ConsoleColor GetExtensionColor( string extension )
      {
         return ConsoleColor.Gray;
      }
   }
}
