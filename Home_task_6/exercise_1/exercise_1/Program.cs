using System.Collections;

namespace exercise_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            int[,] mat = {
                { 1, 2, 3, 4},
                { 5, 6, 7, 8},
                { 9, 10, 11, 12},
                { 13, 14, 15, 16}
            };




            MatrixEnumerator matrix = new MatrixEnumerator(mat);
            Console.WriteLine(matrix.ToString());

            Console.WriteLine("Enumerator1");

            foreach (int item in matrix)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Enumerator2");

            IEnumerator test = matrix.GetEnumerator();
            while (test.MoveNext())
            {
                int item = Convert.ToInt32(test.Current);
                Console.WriteLine(item);
            }
        }
    }
}
