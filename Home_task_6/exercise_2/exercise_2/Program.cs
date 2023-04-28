
namespace exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //Creation of initial arrays
            int[][] test_arr = new int[4][]{
                new int[] { 1, 2, 2, 4, 5, 26, 17, 38},
                new int[] { 11, 32, 23, 24, 5, 36, 71, 8, 55, 148, 0},
                new int[] { 54, 16, 17, 18},
                new int[] { 10, 29, 23, 42, 54, 16, 17, 18, 10, 29, 23, 42, }
            };

            //The first option for solving the problem
            //Output to the console elements from the initial arrays in an ordered order without duplicates and without overwriting in memory
            GreatArray test = new GreatArray(test_arr);

            Console.WriteLine(test.ToString());

            Console.WriteLine("Sorted array from GreatArray:");
            
            foreach (var item in test)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n\n");



            //The second option for solving the problem
            //Obtaining a new array with ordered elements from the original arrays
            GreatArrayMemory test2 = new GreatArrayMemory(test_arr);

            Console.WriteLine(test2.ToString());
            
            int[] sorted_arr = test2.SortedArray;

            Console.WriteLine("Sorted array from GreatArrayMemory:");

            foreach (var item in sorted_arr)
            {
                Console.Write($"{item} ");
            }


            Console.WriteLine("\nEnd");
        }
    }
}