using System;
using System.Collections.Generic;

namespace DirCommand
{
   public interface ISettingsRepository
   {
      Dictionary<string, ConsoleColor> GetFileColors();
   }
}
