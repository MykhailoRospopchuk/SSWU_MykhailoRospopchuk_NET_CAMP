
namespace Lesson_Decorator
{
    //Concrete Decorator
    internal class AddTotalPriceDecorator : Decorator
    {
        public AddTotalPriceDecorator(Component component) : base(component)
        { 
        }

        public override void Print(Order order)
        {
            Console.WriteLine("\n#################__Hello__World__#################\n");
            Console.WriteLine(new string('_', 50));
            base.Print(order);
            Console.WriteLine(new string('_', 50));
            Console.WriteLine($"\nTOTAL_PRICE{order.TotalPrice(),39}".Replace(' ', '.'));
        }
    }
}
