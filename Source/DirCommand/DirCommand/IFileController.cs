namespace DirCommand
{
   public interface IFileController
   {
      FileEntry[] GetFiles( string path );
   }
}
