using System;

namespace DirCommand
{
   [AttributeUsage( AttributeTargets.Method )]
   public class ArgumentHandlerAttribute : Attribute
   {
      private readonly string _argument;

      public string Argument
      {
         get
         {
            return _argument;
         }
      }

      public ArgumentHandlerAttribute( string argument )
      {
         _argument = argument.ToLower();
      }
   }
}
