namespace DirCommand.UnitTest
{
   public static class ObjectExtensions
   {
      public static T[] AsArray<T>( this T instance )
      {
         return new[]
         {
            instance
         };
      }
   }
}
