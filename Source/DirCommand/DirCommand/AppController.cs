namespace DirCommand
{
   public class AppController
   {
      public void Run( string[] arguments )
      {
         if ( arguments == null || arguments.Length == 0 )
         {
            var outputGuy = Dependency.Resolve<IOutputGuy>();

            outputGuy.Syntax();
         }
      }
   }
}
