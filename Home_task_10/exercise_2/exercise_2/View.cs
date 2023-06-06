//Static class for outputting information to the console
namespace exercise_2
{
    internal static class View
    {
        //Output of regular messages to the console
        public static void PrintDelivery(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        //Output of exception messages
        public static void PrintExceptionMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
