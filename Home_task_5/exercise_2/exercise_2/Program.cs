using System.Text;

namespace exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Hello, World!");

            LocalStorage storage = new LocalStorage();
            
            Menu.MainMenu(storage);

        }
    }
}