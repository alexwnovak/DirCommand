using System;
using System.Collections.Generic;

namespace DirCommand
{
   public interface ISettingsRepository
   {
      ConsoleColor GetExtensionColor( string extension );

      Dictionary<string, ConsoleColor> GetFileColors();
   }
}
