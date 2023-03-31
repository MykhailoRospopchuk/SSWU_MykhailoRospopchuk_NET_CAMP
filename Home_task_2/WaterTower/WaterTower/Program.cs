namespace WaterTower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var input = Validator.Input();
            Simulator test = new Simulator(input.Item1, input.Item2, input.Item3, input.Item4);
            test.Start();
            Console.WriteLine(test.ToString());
        }
    }
}