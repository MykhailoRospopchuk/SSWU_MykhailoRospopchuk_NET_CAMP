using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_1
{
    internal interface IOrder
    {
        Guid Id { get; }

        void SetDishes(List<BaseDishes> dishes);
        List<BaseDishes> GetAllDishes();
        List<BaseDishes> GetWaitDishes();
        List<BaseDishes> GetReadyDishes();
        void UpdateStatus(Guid id, DishesState state);
        bool IsOrderFinish();
        List<BaseDishes> GetNotStartedDishes(DishesType dish_type);
        bool IsFinishDishesByType(DishesType dish_type);

    }
}
