//The Observer pattern was used to solve this problem.
//Сlass Controller - subject.
//Class TrafficLights - observer.
namespace exercise_b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Hello, World!");

            InitializerCrossroads crossroads = new InitializerCrossroads();

            crossroads.Start();

            Console.WriteLine("End");
        }
    }
}
