using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exercise_1
{
    internal interface IDishes
    {
        Guid Id { get; }
        int CookingTime { get; }
        string NameDishes { get; }
        int CookingCount { get; }
        DishesType DishesType { get; }

        DishesState CookingState { get; set; }


    }
}
