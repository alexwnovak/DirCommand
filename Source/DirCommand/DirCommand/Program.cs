namespace DirCommand
{
   internal static class Program
   {
      private static void InitDependencyInjection()
      {
         Dependency.CreateUnityContainer();
      }

      private static void Main( string[] arguments )
      {
         InitDependencyInjection();

         new AppController().Run( arguments );
      }
   }
}
