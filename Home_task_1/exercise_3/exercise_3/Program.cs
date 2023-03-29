namespace exercise_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the dimension of the cube (for example 5)");
            int dimension = Convert.ToInt32(Console.ReadLine());
            Cub test = new Cub(dimension);
            var result_front = test.FindFrontWay();
            Console.WriteLine("Front side way (In the direction of the X-axis)");
            if (result_front.Count == 0)
            {
                Console.WriteLine("There are no ways here");
            }
            result_front.ForEach(p => Console.WriteLine("i: 0; j: {0}; k: {1}", p.X, p.Y));

            var result_side = test.FindSideWay();
            Console.WriteLine("Side side way (In the direction of the K-axis)");
            if (result_side.Count == 0)
            {
                Console.WriteLine("There are no ways here");
            }
            result_side.ForEach(p => Console.WriteLine("i: {0}; j: {1}; k: 0", p.X, p.Y));

            var result_top = test.FindTopWay();
            Console.WriteLine("Top side way (In the direction of the J-axis)");
            if (result_top.Count == 0)
            {
                Console.WriteLine("There are no ways here");
            }
            result_top.ForEach(p => Console.WriteLine("i: {0}; j: 0; k: {1}", p.X, p.Y));

            var result_diagonal = test.FindDiagonalWay();
            Console.WriteLine("Diagonal way");
            if (result_diagonal.Count == 0)
            {
                Console.WriteLine("There are no ways here");
            }
            result_diagonal.ForEach(p => Console.WriteLine("Edge number: j:{4}. Entry Point: i:{0} j:{4} k:{1}; Out Point: i:{2} j:{4} k:{3}", p.Entry.X, p.Entry.Y, p.Out.X, p.Out.Y, p.Edge));

            Console.WriteLine("\n");
            test.PrintCub();
        }
    }
}