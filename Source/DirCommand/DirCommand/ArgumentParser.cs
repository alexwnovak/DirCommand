namespace DirCommand
{
   public class ArgumentParser : IArgumentParser
   {
      public RunSettings Parse( string[] arguments )
      {
         var runSettings = new RunSettings();

         runSettings.Path = arguments[0];

         return runSettings;
      }
   }
}
