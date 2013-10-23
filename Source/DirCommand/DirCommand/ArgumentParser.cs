using System;
using System.Collections.Generic;
using System.Reflection;

namespace DirCommand
{
   public class ArgumentParser : IArgumentParser
   {
      private static readonly Dictionary<string, Action<RunSettings>> _argumentHandlers = DiscoverArgumentHandlers();

      private static Dictionary<string, Action<RunSettings>> DiscoverArgumentHandlers()
      {
         var argumentHandlers = new Dictionary<string, Action<RunSettings>>();

         var methods = typeof( ArgumentHandlers ).GetMethods( BindingFlags.Static | BindingFlags.Public );

         foreach ( var method in methods )
         {
            var attributes = method.GetCustomAttributes( typeof( ArgumentHandlerAttribute ), false );

            if ( attributes.Length == 0 )
            {
               // Not a handler--method is not decorated with attribute
               continue;
            }

            string respondsTo = ((ArgumentHandlerAttribute) attributes[0]).Argument;

            var action = (Action<RunSettings>) method.CreateDelegate( typeof( Action<RunSettings> ) );

            argumentHandlers[respondsTo] = action;
         }

         return argumentHandlers;
      }

      public RunSettings Parse( string[] arguments )
      {
         var runSettings = new RunSettings();

         if ( arguments == null || arguments.Length == 0 )
         {
            return runSettings;
         }

         foreach ( string argument in arguments )
         {
            if ( IsProgramSwitch( argument ) )
            {
               Action<RunSettings> handler;

               if ( !_argumentHandlers.TryGetValue( argument.ToLower(), out handler ) )
               {
                  throw new ArgumentException( "Unrecognized argument:" + argument );
               }

               handler( runSettings );
            }
            else
            {
               runSettings.Path = argument;
            }
         }

         return runSettings;
      }

      private static bool IsProgramSwitch( string argument )
      {
         return argument.StartsWith( "/" );
      }
   }
}
