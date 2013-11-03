namespace DirCommand
{
   public interface IDisplayController
   {
      void Display( RunSettings runSettings, FileEntry[] files );

      void ShowError( string message );
   }
}
