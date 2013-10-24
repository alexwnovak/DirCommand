namespace DirCommand
{
   public interface IDisplayController
   {
      void Display( FileEntry[] files );

      void ShowError( string message );
   }
}
