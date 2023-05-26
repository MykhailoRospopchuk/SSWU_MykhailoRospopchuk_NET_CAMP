using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_Decorator
{
    internal class Menu
    {
        Dictionary<string, decimal> _menu;

        public Menu(Dictionary<string, decimal> menu)
        {
            this._menu = new Dictionary<string, decimal>();
            foreach (var item in menu)
            {
                this._menu.Add(item.Key, item.Value);
            }
        }

        public decimal GetPrice(string dish)
        {
            return _menu[dish];
        }
    }
}
