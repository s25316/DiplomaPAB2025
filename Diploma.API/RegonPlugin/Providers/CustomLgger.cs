// Ignore Spelling: Regon, Plugin
namespace RegonPlugin.Providers
{
    internal static class CustomLgger
    {
        public static void Log(string operation, string data)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("REGON: ");

            Console.ResetColor();
            Console.WriteLine(operation);

            Console.WriteLine($"       {data}");
        }
    }
}
