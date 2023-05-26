
namespace Lesson_Decorator
{
    internal class AddClientBalanceDecorator : Decorator
    {
        public AddClientBalanceDecorator(Component component) : base(component)
        {
        }

        public override void Print(Order order)
        {
            
            base.Print(order);
            Console.WriteLine(new string('_', 50));
            Console.WriteLine($"\nYOUR_BALANCE{new Random().Next(50, 10000),38}".Replace(' ', '.'));
            Console.WriteLine(new string('_', 50));
            
        }
    }
}
