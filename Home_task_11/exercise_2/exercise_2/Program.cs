
namespace exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            DB.Init();

            InitArray(100);

            SortController.SortParts();


            Console.WriteLine("\nFor ease of checking the result, a sorted initial array from init file will be output to the console:\n");
            
            int[] sortedFromFile = DB.GetAllLine(DB.PathData._init_path);
            Console.WriteLine(string.Join(" ", sortedFromFile));
        }

        //Create array of random int with set length
        //Write array in init.txt file
        //Output in console init array. 
        private static void InitArray(int numbers)
        {
            Console.WriteLine("Init array with next elements:\n");
            Random random = new Random();

            int[] init = new int[numbers];

            for (int i = 0; i < numbers; i++)
            {
                init[i] = random.Next(0, 100);
                Console.Write(init[i] + " ");
            }
            Console.WriteLine();
            DB.WriteAllLine(init, DB.PathData._init_path);
        }
    }
}