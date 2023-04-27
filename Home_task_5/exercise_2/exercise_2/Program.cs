using System.Text;

namespace exercise_2
{// За результатами перевірки в групі 4-5 завдання у Вас виконано найкраще . Молодець!
    
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
