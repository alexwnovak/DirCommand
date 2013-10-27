using System.Linq;

namespace DirCommand.UnitTest
{
   public static class TestHelper
   {
      public static FileEntry[] GetFileEntries( params string[] fileNames )
      {
         return fileNames.Select( f => new FileEntry
         {
            FullName = f
         } ).ToArray();
      }
   }
}
