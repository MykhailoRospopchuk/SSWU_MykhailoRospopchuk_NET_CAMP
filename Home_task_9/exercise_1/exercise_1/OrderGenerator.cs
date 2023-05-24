
namespace exercise_1
{
    internal class OrderGenerator
    {
        public delegate void OrderGeneratorDelegate(IOrder order);

        public event OrderGeneratorDelegate? OrderNotify;


        private Random _rnd = new Random();
        private bool _stop;
        private List<string> _dishes_pizza = new List<string>()
        {
            "Sicilian pizza",
            "Chicago-style pizza",
            "Neapolitan pizza",
            "Pizza Margherita",
            "California-style pizza",
            "Calzone",
            "Detroit-style pizza",
            "Stromboli",
            "Cheese Pizza",
            "Pepperoni Pizza"
            
        };

        private List<string> _dishes_drinks = new List<string>()
        {
            "Beer",
            "Vodka",
            "Whisky",
            "Pepsi",
            "Juice",
            "Coca-cola",
            "Wine",
            "Samogon"
        };

        private List<string> _dishes_desserts = new List<string>()
        {
            "Pies and Cobblers",
            "Cookies",
            "Cakes",
            "Tarts",
            "Ice Cream"
        };


        public async void GenerateOrder()
        {
            while (!_stop)
            {
                List<BaseDishes> dishes = new List<BaseDishes>();

                List<string> dish_pizza_name = _dishes_pizza.OrderBy(x => _rnd.Next()).Take(_rnd.Next(1, _dishes_pizza.Count - 1)).ToList();
                dish_pizza_name.ForEach(pizza => dishes.Add(new BaseDishes(_rnd.Next(1, 5), pizza, _rnd.Next(1, 5), DishesType.Pizza)));

                List<string> dish_drinks_name = _dishes_drinks.OrderBy(x => _rnd.Next()).Take(_rnd.Next(1, _dishes_drinks.Count - 1)).ToList();
                dish_drinks_name.ForEach(drinks => dishes.Add(new BaseDishes(_rnd.Next(1, 3), drinks, _rnd.Next(1, 5), DishesType.Drinks)));

                List<string> dish_desserts_name = _dishes_desserts.OrderBy(x => _rnd.Next()).Take(_rnd.Next(1, _dishes_desserts.Count - 1)).ToList();
                dish_desserts_name.ForEach(desserts => dishes.Add(new BaseDishes(_rnd.Next(1, 2), desserts, _rnd.Next(1, 5), DishesType.Desserts)));


                Order current_order = new Order();
                current_order.SetDishes(dishes);

                View.PrintWithOutTime("\n");
                View.PrintWithTime($"______________ New Order was generated! ______________ Order ID {current_order.Id}");
                View.PrintWithOutTime($"{current_order}");

                OrderNotify?.Invoke(current_order);

                //Generation of orders with a random interval from 1 to 20 seconds
                //await Task.Delay(_rnd.Next(1, 20) * 1000); 

                //Generation of orders with a given interval
                await Task.Delay(25000);
            }

        }

        public void RequestStop(bool command)
        {
            _stop = command;
        }

    }
}
