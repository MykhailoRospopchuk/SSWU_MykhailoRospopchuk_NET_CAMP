using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_1
{
    internal class Order : IOrder
    {
        private List<BaseDishes> _dishes = new List<BaseDishes>();
        private Guid _id = Guid.NewGuid();

        public Guid Id { get { return _id; } }

        public List<BaseDishes> GetAllDishes()
        {
            return _dishes;
        }

        public List<BaseDishes> GetReadyDishes()
        {
            return _dishes.Where(_dishes => _dishes.CookingState == DishesState.Finish).ToList();
        }

        public List<BaseDishes> GetWaitDishes()
        {
            return _dishes.Where(_dishes => _dishes.CookingState == DishesState.InProgres).ToList();
        }

        public bool IsOrderFinish()
        {
            bool finsh_all = true;
            
            _dishes.ForEach(dishes => {
                if (dishes.CookingState != DishesState.Finish)
                {
                    finsh_all = false;
                }
            });
            return finsh_all;
        }

        public void SetDishes(List<BaseDishes> dishes)
        {
            dishes.ForEach(x => 
            {
                if (!_dishes.Contains(x))
                {
                    _dishes.Add(x.Clone());
                }
            });
        }

        public void UpdateStatus(Guid id, DishesState state)
        {
            BaseDishes current = _dishes.Find(order => order.Id == id);

            current.CookingState = state;
        }


        public List<BaseDishes> GetNotStartedDishes(DishesType dish_type)
        {
            List<BaseDishes> current = _dishes.Where(dish => (dish.DishesType == dish_type) && (dish.CookingState == DishesState.Wait)).ToList();
            return current;
        }

        public bool IsFinishDishesByType(DishesType dish_type)
        {
            List<BaseDishes> current = _dishes.Where(dish => (dish.DishesType == dish_type)).ToList();
            foreach (var item in current)
            {
                if (item.CookingState != DishesState.Finish)
                {
                    return false;
                }
            }
            return true;
        }

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            _dishes.ForEach(x => sb.AppendLine(x.ToString()));

            return sb.ToString();
        }
    }
}
