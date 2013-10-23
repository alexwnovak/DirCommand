namespace DirCommand
{
   internal static class ArgumentHandlers
   {
      [ArgumentHandler( "/l" )]
      public static void ParseLowercaseFlag( RunSettings runSettings )
      {
         runSettings.DisplayAsLowercase = true;
      }

      [ArgumentHandler( "/r" )]
      public static void ParseRecursionFlag( RunSettings runSettings )
      {
         runSettings.RecurseSubdirectories = true;
      }
   }
}
