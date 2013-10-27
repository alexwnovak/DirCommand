namespace DirCommand
{
   internal static class Program
   {
      private static void InitDependencyInjection()
      {
         Dependency.CreateUnityContainer();
         Dependency.RegisterType<IArgumentParser, ArgumentParser>();
         Dependency.RegisterType<IFileController, FileController>();
         Dependency.RegisterType<IFileSystem, FileSystem>();
         Dependency.RegisterType<IDisplayController, DisplayController>();
         Dependency.RegisterType<IConsoleAdapter, ConsoleAdapter>();
         Dependency.RegisterType<ISettingsRepository, SettingsRepository>();
      }

      private static int Main( string[] arguments )
      {
         InitDependencyInjection();

         return new AppController().Run( arguments );
      }
   }
}
