
namespace exercise_1
{
    internal class Manager
    {
        List<IOrder> _active_orders = new List<IOrder>();

        ICook _order_handler;

        bool _is_empty = false;

        public void SetOrders(IOrder orders)
        {
            _active_orders.Add(orders);

            CountCurrentActive();

            if (_is_empty)
            {
                StartCooking();
            }

        }

        public void SetChain(ICook order_handler)
        {
            _order_handler = order_handler;
        }

        public void StartCooking()
        {
            CheckOrders();
            _order_handler.OrderHandle(_active_orders.First());
        }

        private void CheckOrders()
        {
            _active_orders.ForEach(order => {
                if (order.IsOrderFinish()) 
                {
                    View.PrintWithOutTime("\n");
                    View.PrintWithTime($"______________ Order was finished! ______________ Order ID {order.Id}");
                    View.PrintWithOutTime($"{order}");

                    CountCurrentActive();
                }
            });
            _active_orders.RemoveAll(order => order.IsOrderFinish());
            if (_active_orders.Count == 0)
            {
                View.PrintWithOutTime("Manager wait for new Orders\n");
                _is_empty = true;
            }
        }

        private void CountCurrentActive()
        {
            View.PrintWithOutTime($"The number of unfinished orders: {_active_orders.Count(order => !order.IsOrderFinish())}\n");
        }
    }
}
