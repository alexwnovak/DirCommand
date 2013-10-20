namespace DirCommand
{
   public interface IArgumentParser
   {
      RunSettings Parse( string[] arguments );
   }
}
