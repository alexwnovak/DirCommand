namespace DirCommand
{
   public class ArgumentParser : IArgumentParser
   {
      public RunSettings Parse( string[] arguments )
      {
         if ( arguments == null || arguments.Length == 0 )
         {
            return new RunSettings();
         }

         var runSettings = new RunSettings();

         runSettings.Path = arguments[0];

         return runSettings;
      }
   }
}
