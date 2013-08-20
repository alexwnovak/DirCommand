namespace DirCommand
{
   internal static class Program
   {
      private static void InitDependencyInjection()
      {
         Dependency.CreateUnityContainer();
         Dependency.RegisterType<IFileSystem, FileSystem>();
         Dependency.RegisterType<IConsoleAdapter, ConsoleAdapter>();
      }

      private static void Main( string[] arguments )
      {
         InitDependencyInjection();

         new AppController().Run( arguments );
      }
   }
}
