using System;

namespace DirCommand
{
   public interface ISettingsRepository
   {
      ConsoleColor GetExtensionColor( string extension );
   }
}
