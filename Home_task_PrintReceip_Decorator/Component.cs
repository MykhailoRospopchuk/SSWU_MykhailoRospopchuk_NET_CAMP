using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_Decorator
{
    //Component Interface
    internal abstract class Component
    {
        public abstract void Print(Order order);
    }
}
