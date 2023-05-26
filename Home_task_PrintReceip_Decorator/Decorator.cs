using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_Decorator
{
    internal abstract class Decorator : Component
    {
        protected Component _component;

        protected Decorator(Component component)
        {
            _component = component;
        }

        public override void Print(Order order)
        {
            if (_component != null)
            {
                _component.Print(order);
            }
        }
    }
}
