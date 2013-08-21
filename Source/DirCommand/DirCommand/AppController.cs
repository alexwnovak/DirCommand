﻿namespace DirCommand
{
   public class AppController
   {
      public void Run( string[] arguments )
      {
         var fileSystem = Dependency.Resolve<IFileSystem>();

         var files = fileSystem.GetFiles( "." );

         var consoleAdapter = Dependency.Resolve<IConsoleAdapter>();

         foreach ( string file in files )
         {
            consoleAdapter.WriteLine( file );
         }
      }
   }
}
