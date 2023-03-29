using System;

namespace exercise_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Tensor test = new Tensor(4);
            int[] where = { 2, 2, 1 };
            test.InitializationTensor(3, 5, 2);
            Console.WriteLine(test.ToString());
            test.SetValue(9, 1, 2, 0);
            Console.WriteLine(test.GetValue(where));
            Console.WriteLine(test.GetValue(0, 3, 0));
            test[1, 1, 0] = 44;
            Console.WriteLine("Print element: {0}", test[1, 1, 0]);

            Console.WriteLine(test.ToString());

            Tensor test2 = new Tensor(1);
            test2.InitializationTensor(1);
            Console.WriteLine(test2.ToString());
            test2.SetValue(9, 0);
            Console.WriteLine(test2.ToString());

            Tensor test3 = new Tensor(2);
            test3.InitializationTensor(88);
            test3.SetValue(88438, 1);
            test3[22] = 5874;
            Console.WriteLine(test3.ToString());
        }
    }
}
