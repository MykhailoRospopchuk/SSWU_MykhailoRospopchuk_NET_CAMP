//The first option for solving the problem

//In this class, the execution of the task is organized without writing to the memory of the collection.
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
        public IEnumerator GetEnumerator()
        {
            int currnent = 0;
            int previous_min = FindMin();
            int max = FindMax();
      
            while (previous_min < max)
            {
                int min = max;
                for (int i = 0; i < _income_arrays.Length; i++)
                {
                    for (int j = 0; j < _income_arrays[i].Length; j++)
                    {
                        if (_income_arrays[i][j] < min && _income_arrays[i][j] > previous_min)
                        {
                            min = _income_arrays[i][j];
                        }
                    }
                }
                currnent++;
                previous_min = min;
                yield return min;
            }
        }

        public override string? ToString()
        {
            StringBuilder result_str = new StringBuilder();
            result_str.AppendLine("Income arrays from GreatArray:");
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
