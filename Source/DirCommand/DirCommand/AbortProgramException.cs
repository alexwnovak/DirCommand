using System;
using System.Runtime.Serialization;

namespace DirCommand
{
   [Serializable]
   public class AbortProgramException : Exception
   {
      private readonly int _exitCode;

      public int ExitCode
      {
         get
         {
            return _exitCode;
         }
      }

      public AbortProgramException( int exitCode )
      {
         _exitCode = exitCode;
      }

      public AbortProgramException( string message )
         : base( message )
      {
      }

      public AbortProgramException( string message, Exception inner )
         : base( message, inner )
      {
      }

      protected AbortProgramException( SerializationInfo info, StreamingContext context )
         : base( info, context )
      {
      }
   }
}
