namespace DirCommand
{
   public class RunSettings
   {
      public static string DefaultPath = ".";

      public string Path
      {
         get;
         set;
      }

      public bool RecurseSubdirectories
      {
         get;
         internal set;
      }

      public bool DisplayAsLowercase
      {
         get;
         internal set;
      }

      public RunSettings()
      {
         Path = DefaultPath;
      }
   }
}
