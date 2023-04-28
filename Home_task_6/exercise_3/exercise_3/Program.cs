namespace exercise_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!\n");
            string test = "qwerty qwert qwe qwerty1 12 123 123 1234";
            
            Console.WriteLine("Default string:\n" + test);

            Unique seelcter = new Unique(test);
            
            Console.WriteLine(seelcter.ToString());

            Console.WriteLine("Only unique words");
            foreach (var item in seelcter)
            {
                Console.WriteLine(item);
            }
        }
    }
}