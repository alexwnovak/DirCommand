using System;

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

         foreach ( string argument in arguments )
         {
            if ( argument.StartsWith( "/" ) )
            {
               if ( argument.ToLower() == "/r" )
               {
                  runSettings.RecurseSubdirectories = true;
               }
               else if ( argument.ToLower() == "/l" )
               {
                  runSettings.DisplayAsLowercase = true;
               }
               else
               {
                  throw new ArgumentException( "Unrecognized argument:" + argument );
               }
            }
            else
            {
               runSettings.Path = argument;               
            }
         }

         return runSettings;
      }
   }
}
