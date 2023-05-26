namespace Lesson_Decorator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Dictionary<string, decimal> menu = new Dictionary<string, decimal>()
            {
                { "Sicilian_pizza", 15},
                { "Chicago-style_pizza", 20},
                { "Neapolitan_pizza", 33},
                { "Pizza_Margherita", 48},
                { "California-style_pizza", 25},
                { "Calzone", 26},
                { "Detroit-style_pizza", 15},
                { "Stromboli", 17},
                { "Cheese_Pizza", 11},
                { "Pepperoni_Pizza", 40},
                { "Beer", 22},
                { "Vodka", 62},
                { "Whisky", 15},
                { "Pepsi", 7},
                { "Juice", 6},
                { "Coca-cola", 4},
                { "Wine", 35},
                { "Samogon", 1500},
                { "Pies_and_Cobblers", 55},
                { "Cookies", 14},
                { "Tarts", 21},
                { "Ice_Cream", 7}
            };

            Dictionary<string, uint> order = new Dictionary<string, uint>()
            {
                { "Sicilian_pizza", 1},
                { "Calzone", 6},
                { "Pepperoni_Pizza", 2},
                { "Beer", 15},
                { "Vodka", 20},
                { "Pepsi", 7},
                { "Samogon", 1},
                { "Pies_and_Cobblers", 5},
                { "Ice_Cream", 2}
            };

            Menu current_menu = new Menu(menu);
            Order current_order = new Order(order);
            current_order.GetPriceHandler += current_menu.GetPrice;

            //Create Concrete object
            ReceiptPrinter receiptPrinter = new ReceiptPrinter();

            //Create first Decorator
            AddTotalPriceDecorator addTotalPriceDecorator = new AddTotalPriceDecorator(receiptPrinter);

            //Create second Decorator
            AddClientBalanceDecorator addClientBalanceDecorator = new AddClientBalanceDecorator(addTotalPriceDecorator);

            //Create third decorator
            AddSaleDecorator addSaleDecorator = new AddSaleDecorator(addClientBalanceDecorator);

            addSaleDecorator.Print(current_order);
        }
    }
}