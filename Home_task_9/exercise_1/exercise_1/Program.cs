using System.Diagnostics;

namespace exercise_1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            View.PrintWithTime("Hello, World!");

            Stopwatch sw = new Stopwatch();

            OrderGenerator order_generator = new OrderGenerator();

            List<OneCook> first_chain = new List<OneCook>()
            {
                new OneCook("Petro"),
                new OneCook("Anton"),
                new OneCook("Oleg")
            };

            List<OneCook> second_chain = new List<OneCook>()
            {
                new OneCook("Borus"),
                new OneCook("Kaban")
            };

            List<OneCook> third_chain = new List<OneCook>()
            {
                new OneCook("Baran")
            };


            //Chain organization
            CookPizzaHandler pizza_handler = new CookPizzaHandler(DishesType.Pizza, first_chain);
            CookDrinkHandler drink_handler = new CookDrinkHandler(DishesType.Drinks, second_chain);
            CookDessertsHandler dessert_handler = new CookDessertsHandler(DishesType.Desserts, third_chain);

            pizza_handler.SetNext(drink_handler).SetNext(dessert_handler);



            Manager manager = new Manager();

            dessert_handler.AskOrder += manager.StartCooking;

            order_generator.OrderNotify += manager.SetOrders;

            manager.SetChain(pizza_handler);

            Thread GeneratorThread = new Thread(order_generator.GenerateOrder);
            Thread ManagerThread = new Thread(manager.StartCooking);


            GeneratorThread.Start();

            Thread.Sleep(200);

            ManagerThread.Start();

            Thread.Sleep(10000000);

            order_generator.RequestStop(true);

            Console.WriteLine("End");
        }
    }
}