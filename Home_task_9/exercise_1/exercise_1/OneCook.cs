namespace exercise_1
{
    internal class OneCook : IClonable<OneCook>
    {
        public delegate void AskNewDishDelegate(OneCook current_cook);

        public event AskNewDishDelegate? AskDish;

        private readonly string _name;

        public OneCook(string name)
        {
            _name = name;
        }

        public async Task MakeDish(IDishes dish)
        {
            dish.CookingState = DishesState.InProgres;

            View.PrintWithTime($"\t{this} start cooking: {dish.NameDishes,-24} - {dish.DishesType}");

            await Task.Delay(dish.CookingTime * dish.CookingCount);
            dish.CookingState = DishesState.Finish;

            AskDish?.Invoke(this);
        }

        public override string? ToString()
        {
            return $"{_name,-6}";
        }

        public OneCook Clone()
        {
            return new OneCook(_name);
        }

    }
}
