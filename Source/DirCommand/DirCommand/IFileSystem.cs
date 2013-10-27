namespace DirCommand
{
   public interface IFileSystem
   {
      string[] GetDirectories( string path );

      FileEntry[] GetFiles( string path );
   }
}
