//The delivery cost calculation is based on the Visitor pattern
//interface IDeliveryCalculator - Visitor interface
//interface IProduct - interface concrete component
namespace exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //Create Visitor
            IDeliveryCalculator calculator = new DeliveryCalculator();

            //Create provider that executes commands
            DeliveryProvider provider = new DeliveryProvider(calculator);
            //Read data from txt files
            provider.LoadItem();
            //Calculate the cost of delivery with the help of the visitor
            provider.CalculateDelivery();
        }
    }
}