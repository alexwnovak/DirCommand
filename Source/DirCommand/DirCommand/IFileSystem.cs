namespace DirCommand
{
   public interface IFileSystem
   {
      string[] GetDirectories( string path );

      string[] GetFiles( string path );

      FileEntry[] GetContents( string path );
   }
}
