namespace DirCommand
{
   internal static class Program
   {
      private static void InitDependencyInjection()
      {
         Dependency.CreateUnityContainer();
         Dependency.RegisterType<IFileController, FileController>();
         Dependency.RegisterType<IConsoleAdapter, ConsoleAdapter>();
         Dependency.RegisterType<IArgumentParser, ArgumentParser>();
         Dependency.RegisterType<IDisplayController, DisplayController>();
      }

      private static int Main( string[] arguments )
      {
         InitDependencyInjection();

         return new AppController().Run( arguments );
      }
   }
}
