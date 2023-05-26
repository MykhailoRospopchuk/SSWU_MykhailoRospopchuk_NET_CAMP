using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_Decorator
{
    //Concrete Component
    internal class ReceiptPrinter : Component
    {
        public override void Print(Order order)
        {
            Console.WriteLine(order);
        }
    }
}
