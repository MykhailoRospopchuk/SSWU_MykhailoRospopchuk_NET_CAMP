namespace Lesson_Decorator
{
    internal class AddSaleDecorator : Decorator
    {
        public AddSaleDecorator(Component component) : base(component)
        {
        }

        public override void Print(Order order)
        {
            base.Print(order);
            Console.WriteLine("\nDISCOUNT OF THE WEEK\n");
            Console.WriteLine("Astrologers announced a week of collapse\nin prices for toothpicks");
            Console.WriteLine(new string('_', 50));
            Console.WriteLine("\n#################__Hello__World__#################\n");
        }
    }
}
