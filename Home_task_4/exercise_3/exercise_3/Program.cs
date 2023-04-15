using System.Globalization;
using System.Text;

namespace exercise_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            CultureInfo.CurrentCulture = new CultureInfo("ua-UA", false);

            Console.WriteLine("Hello, World!");

            Menu.MainMenu();
        }
    }
}