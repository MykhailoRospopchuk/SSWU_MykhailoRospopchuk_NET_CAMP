namespace WaterTower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Simulator test = new Simulator(3, 8, 44, 8);
            test.Start();
        }
    }
}