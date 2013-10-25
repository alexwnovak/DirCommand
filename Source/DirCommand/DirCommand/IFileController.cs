namespace DirCommand
{
   public interface IFileController
   {
      FileEntry[] GetFiles( string path );

      void Run( RunSettings runSettings );
   }
}
