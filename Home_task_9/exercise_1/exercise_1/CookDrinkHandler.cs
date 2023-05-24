
namespace exercise_1
{
    internal class CookDrinkHandler : BaseCook, ICooKHandler
    {
        private DishesType _cook_type;

        private object _request;

        private List<OneCook> _cook = new List<OneCook>();

        public CookDrinkHandler(DishesType cook_type, List<OneCook> cook)
        {
            _cook_type = cook_type;

            cook.ForEach(x => _cook.Add(x.Clone()));

            SubscribeCook();
        }

        public DishesType CookType { get { return _cook_type; } }

        public override async void OrderHandle(object request)
        {
            //View.PrintWithTime("\t\t____CookDrinkHandler start cooking____");

            IOrder current_order;
            List<BaseDishes> current_dishes;
            int max = _cook.Count;

            if (request is IOrder)
            {
                _request = request;
                current_order = request as IOrder;
                current_dishes = current_order.GetNotStartedDishes(_cook_type);

                if (current_dishes.Count != 0)
                {
                    View.PrintWithTime($"\t\t____CookDrinkHandler start cooking____Order ID: {current_order.Id}");
                    if (current_dishes.Count < max)
                    {
                        max = current_dishes.Count;
                    }
                    for (int i = 0; i < max; i++)
                    {
                        _cook[i].MakeDish(current_dishes[i]);
                    }
                }
            }
        }

        private void GivNewDishCook(OneCook current_cook)
        {

            IOrder current_order;
            List<BaseDishes> current_dishes;

            if (_request is IOrder)
            {
                current_order = _request as IOrder;

                if (current_order.IsFinishDishesByType(_cook_type))
                {
                    CallNextHandler(_request);
                }
                else
                {
                    current_dishes = current_order.GetNotStartedDishes(_cook_type);
                    current_cook.MakeDish(current_dishes.First());
                }
            }
        }


        private void CallNextHandler(object request)
        {
            base.OrderHandle(request);
        }

        private void SubscribeCook()
        {
            foreach (var cook in _cook)
            {
                cook.AskDish += GivNewDishCook;
            }
        }
    }
}
