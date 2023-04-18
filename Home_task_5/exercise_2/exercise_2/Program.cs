namespace exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            LocalStorage storage = new LocalStorage();
            
            Menu.MainMenu(storage);

        }
    }
}