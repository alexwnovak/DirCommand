namespace DirCommand
{
   public interface IDisplayController
   {
      void Display( string[] files );

      void ShowError( string message );
   }
}
