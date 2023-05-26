using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_Decorator
{
    

    internal class Order
    {
        public delegate decimal GetPrice(string product);
        public event GetPrice GetPriceHandler;

        Dictionary<string, uint> _order;

        public Order(Dictionary<string, uint> order)
        {
            this._order = order;
        }

        public decimal? TotalPrice()
        {
            decimal? sum = 0;
            foreach (var item in _order)
            {
                sum += GetPriceHandler?.Invoke(item.Key) * item.Value;
            }
            return sum;
        }

        public override string ToString()
        {
            decimal? price;
            StringBuilder result = new StringBuilder();
            foreach (var item in _order)
            {
                price = GetPriceHandler?.Invoke(item.Key);
                result.Append($"{item.Key,-27}{item.Value,8}".Replace(' ', '.'));
                result.Append($" x{price,6}");
                result.Append($" ={price*item.Value,5}\n");
            }

            return result.ToString();
        }
    }
}
