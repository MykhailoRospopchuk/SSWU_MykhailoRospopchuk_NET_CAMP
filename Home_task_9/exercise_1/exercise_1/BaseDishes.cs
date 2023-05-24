using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace exercise_1
{
    internal class BaseDishes : IDishes, IClonable<BaseDishes>
    {
        private int _cooking_time;
        private string _name;
        private int _count;
        private DishesState _dish_state = DishesState.Wait;
        private Guid _id;
        private DishesType _dish_type;

        public BaseDishes(int time, string name, int count, DishesType type)
        {
            _id = Guid.NewGuid();
            _cooking_time = time * 1000;
            _name = name;
            _count = count;
            _dish_type = type;
        }

        public Guid Id { get { return _id; } }

        public int CookingTime { get {return _cooking_time; } }

        public string NameDishes { get { return _name; } }

        public int CookingCount { get { return _count; } }

        public DishesState CookingState { 
            get {  return _dish_state; }
            set { _dish_state = value; }
        }

        public DishesType DishesType { get { return _dish_type; } }

        public BaseDishes Clone()
        {
            return new BaseDishes(_cooking_time/1000, _name, _count, _dish_type);
        }

        public override string? ToString()
        {
            return $"{_name,-24} - Count: {_count, -2} - Cooking Time: {_cooking_time/1000,2}c - Status: {_dish_state} - Type: {_dish_type, 10}";
        }
    }
}
