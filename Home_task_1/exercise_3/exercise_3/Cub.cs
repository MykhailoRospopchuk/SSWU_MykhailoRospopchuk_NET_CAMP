//This class is designed to work with 3D arrays.
//Implementation of the search for horizontal, vertical and diagonal ways in Cub
// З назвами зрозуміліше, але менш ефективно. 
// Але в цілому алгорим продуманий і з уникненням повторів. Просто можна трішки лаконічніше...
namespace exercise_3
{
    internal class Cub: EdgeCub
    {
        private readonly int[,,] _cub;
        private readonly int _size;

        public Cub(int size)
            :base(size)
        {
            this._cub = GenerateCub(size);
            this._size = size;
        }

        //A method for creating a three-dimensional array of given dimensions and filling it with random numbers 0 and 1
        private int[,,] GenerateCub(int size)
        {
            Random random = new();
            int[,,] result_cub = new int[size, size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int k = 0; k < size; k++)
                    {
                        result_cub[i, j, k] = random.Next(0, 2);
                    }
                }
            }

            //We mark the vertices of the cube for orientation when displaying the cube in the console
            result_cub[0, 0, 0] = 9; // We use the number 9 instead of 1 to avoid confusion with other units
            result_cub[0, size-1, 0] = 2;
            result_cub[size-1, size-1, 0] = 3;
            result_cub[size-1, 0, 0] = 4;
            result_cub[0, 0, size - 1] = 5;
            result_cub[0, size - 1, size - 1] = 6;
            result_cub[size - 1, size - 1, size - 1] = 7;
            result_cub[size - 1, 0, size - 1] = 8;

            return result_cub;
        }

        //Finding the hole in the Front projection 9-5-6-2
        //Algorithm description:
        //  1. First, we take the first section of the cube.
        //  2. We find zero elements in it that are not on the boundary.These will be the potential beginnings of holes.
        //  3. We organize a cycle for each of the entry points.We select the next section two-dimensional matrix in which it lies and check whether there is a through hole.
        //  4. If the hole is through, then we save the coordinates of the point.
        public List<Point> FindFrontWay()
        {
            var current_edge = GetOneEdge(0, "front"); //Got first section of the cube.
            var list_result = FindWayPoint(current_edge); //Find zero elements in current section

            for (int iterator = 1; iterator < _size; iterator++)
            {
                current_edge = GetOneEdge(iterator, "front"); //Got next section of the cube.
                list_result = CheckWayPoint(list_result, current_edge); // Check whether there is an empty place in this section according to the coordinates of the empty points from the previous section
            }
            return list_result;
        }
        //Finding the hole in the Side projection 9-2-3-4
        //Algorithm description:
        //  1. First, we take the first section of the cube.
        //  2. We find zero elements in it that are not on the boundary.These will be the potential beginnings of holes.
        //  3. We organize a cycle for each of the entry points.We select the next section two-dimensional matrix in which it lies and check whether there is a through hole.
        //  4. If the hole is through, then we save the coordinates of the point.

        public List<Point> FindSideWay()
        {
            var current_edge = GetOneEdge(0, "side"); //Got first section of the cube.
            var list_result = FindWayPoint(current_edge); //Find zero elements in current section

            for (int iterator = 1; iterator < _size; iterator++)
            {
                current_edge = GetOneEdge(iterator, "side"); //Got next section of the cube.
                list_result = CheckWayPoint(list_result, current_edge); // Check whether there is an empty place in this section according to the coordinates of the empty points from the previous section
            }
            return list_result;
        }
        //Finding the hole in the Side projection 9-5-8-4
        //Algorithm description:
        //  1. First, we take the first section of the cube.
        //  2. We find zero elements in it that are not on the boundary.These will be the potential beginnings of holes.
        //  3. We organize a cycle for each of the entry points.We select the next section two-dimensional matrix in which it lies and check whether there is a through hole.
        //  4. If the hole is through, then we save the coordinates of the point.
        public List<Point> FindTopWay()
        {
            var current_edge = GetOneEdge(0, "top"); //Got first section of the cube.
            var list_result = FindWayPoint(current_edge); //Find zero elements in current section

            for (int iterator = 1; iterator < _size; iterator++)
            {
                current_edge = GetOneEdge(iterator, "top"); //Got next section of the cube.
                list_result = CheckWayPoint(list_result, current_edge); // Check whether there is an empty place in this section according to the coordinates of the empty points from the previous section
            }
            return list_result;
        }
        //Finding a diagonal hole that is parallel to the top surface
        //Algorithm description:
        //Algorithm description:
        //1. We take two-dimensional arrays in turn that are parallel to the diagonals of the upper section.
        //2. In the resulting array, we determine the probable entry points on the boundaries of the array.
        //3. We organize a cycle for each entry point and check whether it is the beginning of a hole in this section
        public List<Way> FindDiagonalWay()
        {
            List<Way> way_diagonal = new();
            for (int i = 1; i < _size - 1; i++)
            {
                var current_edge = GetOneEdge(i, "top"); //Got first section of the cube from Top.
                var list_entry_left = FindLeftDiagonalEntry(current_edge); //Got the possible entry points of the holes from Left to Right
                var list_entry_right = FindRightDiagonalEntry(current_edge); //Got the possible entry points of the holes from Right to Left

                // check whether it is the beginning of a hole in this section
                for (int iterator = 0; iterator < list_entry_left.Count; iterator++)
                {
                    var out_point = CheckWayLeftDiagonalPoint(list_entry_left[iterator], current_edge);
                    if (out_point != null)
                    {
                        way_diagonal.Add(new Way(i, list_entry_left[iterator], out_point));
                    }
                }

                // check whether it is the beginning of a hole in this section
                for (int iterator = 0; iterator < list_entry_right.Count; iterator++)
                {
                    var out_point = CheckWayRightDiagonalPoint(list_entry_right[iterator], current_edge);
                    if (out_point != null)
                    {
                        way_diagonal.Add(new Way(i, list_entry_right[iterator], out_point));
                    }
                }
            }
            return way_diagonal;
        }

        //Use the method to obtain the indicated two-dimensional array from a cube
        private int[,] GetOneEdge(int edge, string direction)
        {
            int[,] result = new int[_size, _size];
            for (int a = 0; a < _size; a++)
            {
                for (int b = 0; b < _size; b++)
                {
                    switch (direction)
                    {
                        case "front":
                            result[a, b] = _cub[edge, a, b];
                            break;
                        case "side":
                            result[a, b] = _cub[a, b, edge];
                            break;
                        case "top":
                            result[a, b] = _cub[a, edge, b];
                            break;
                        default:
                            Console.WriteLine("Wrong direction");
                            break;
                    }
                }
            }
            return result;
        }

        //A method for printing a cube to the console
        public void PrintCub()
        {
            Console.WriteLine("Print Cub from Front to Back");
            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine("Axis number: i:{0}", i);
                for (int j = 0; j < _size; j++)
                {
                    for (int k = 0; k < _size; k++)
                    {
                        Console.Write("{0} ",_cub[i, j, k]);
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Print Cub from Left Side to Right Side");
            for (int k = 0; k < _size; k++)
            {
                Console.WriteLine("Axis number: k:{0}", k);
                for (int i = 0; i < _size; i++)
                {
                    for (int j = 0; j < _size; j++)
                    {
                        Console.Write("{0} ", _cub[i, j, k]);
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Print Cub from Top to Bottom");
            for (int j = 0; j < _size; j++)
            {
                Console.WriteLine("Axis number: j:{0}", j);
                for (int i = 0; i < _size; i++)
                {
                    for (int k = 0; k < _size; k++)
                    {
                        Console.Write("{0} ", _cub[i, j, k]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
