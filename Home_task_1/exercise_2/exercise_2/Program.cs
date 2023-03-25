namespace exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            
            Color test = new Color(20, 20);
            test.GenerateColor(0, 16);
            Console.WriteLine(test.ToString());
            test.ColorLine();
        }
    }
}