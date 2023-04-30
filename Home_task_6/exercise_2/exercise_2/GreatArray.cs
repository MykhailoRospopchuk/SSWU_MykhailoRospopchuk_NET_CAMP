//The first option for solving the problem

//In this class, the execution of the task is organized without writing to the memory copy of the collection.
//The program outputs the elements from the initial arrays in sorted order to the console

using System.Collections;
using System.Text;

namespace exercise_2
{
    internal class GreatArray
    {
        private readonly int[][] _income_arrays;

        public GreatArray(int[][] income_arrays)
        {
            if (income_arrays != null)
            {
                _income_arrays = income_arrays;
            }
        }

        private int FindMax()
        {
            int max = _income_arrays[0][0];
            for (int i = 0; i < _income_arrays.Length; i++)
            {
                for (int j = 0; j < _income_arrays[i].Length; j++)
                {
                    if (_income_arrays[i][j] > max)
                    {
                        max = _income_arrays[i][j];
                    }
                }
            }
            return max;
        }

        private int FindMin()
        {
            int min = _income_arrays[0][0];
            for (int i = 0; i < _income_arrays.Length; i++)
            {
                for (int j = 0; j < _income_arrays[i].Length; j++)
                {
                    if (_income_arrays[i][j] < min)
                    {
                        min = _income_arrays[i][j];
                    }
                }
            }
            return min;
        }

        //We output the input arrays in sorted order. Each smallest number found is saved for the next iteration.
        //If there is an element in the iteration that has already been output, it is skipped.
        //If there is a duplicate of the smallest value, it is displayed on the screen, and the coordinates are recorded in the current variable,
        //for further verification on subsequent iterations.
        //At each iteration of the outer loop, we look for the smallest number in the input arrays, but more than the previously found smallest
        public IEnumerator GetEnumerator()
        {
            int currnent = 0;
            int previous_min = FindMin();
            int max = FindMax();
            int current_i = 0;
            int current_j = 0;
            Point current_point = new Point(_income_arrays[0][0], 0, 0);

            while (previous_min < max)
            {
                int min = max;
                for (int i = 0; i < _income_arrays.Length; i++)
                {
                    for (int j = 0; j < _income_arrays[i].Length; j++)
                    {
                        if (_income_arrays[i][j] <= min && _income_arrays[i][j] >= previous_min)
                        {
                            //If the found potential minimum was already found earlier, then we proceed to another iteration
                            if (current_point.CheckCoordinate(_income_arrays[i][j], i, j)) 
                                continue;
                            current_i = i;
                            current_j = j;
                            min = _income_arrays[i][j];
                        }
                    }
                }
                //Enter the value and coordinates of the minimum number into the current variable. Later in the cycle, a check for duplicates will be performed
                current_point.AddCoordinate(min, current_i, current_j);
                currnent++;
                previous_min = min;
                yield return min;
            }
        }

        public override string? ToString()
        {
            StringBuilder result_str = new StringBuilder();
            result_str.AppendLine("Income arrays in GreatArray:");
            foreach (var item in _income_arrays)
            {
                foreach (var temp in item)
                {
                    result_str.Append($"{temp,-4}");
                }
                result_str.AppendLine();
            }
            return result_str.ToString();
        }
    }
}
