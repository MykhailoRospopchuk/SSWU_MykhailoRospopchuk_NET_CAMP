//The second option for solving the problem

//In this class, the execution of the task is organized by writing the complete collection to memory.
//After which it is sorted and an array with sorted elements is returned

using System.Collections;
using System.Text;

namespace exercise_2
{
    internal class GreatArrayMemory
    {
        private readonly int[][] _income_arrays;
        private int[] _sorted_array = null;

        public GreatArrayMemory(int[][] income_arrays)
        {
            if (income_arrays != null)
            {
                _income_arrays = (int[][])income_arrays.Clone();
                CreateArray();
                SorteArray();
            }
        }

        public int[] SortedArray
        {
            get { return _sorted_array; }
        }

        public IEnumerable ToEnumerable()
        {
            foreach (var item in _income_arrays)
            {
                foreach (var temp in item)
                {
                    yield return temp;
                }
            }
        }

        private void CreateArray()
        {
            var res = ToEnumerable();
            var res_ienumerable = res.Cast<int>();
            _sorted_array = res_ienumerable.ToArray();
        }

        private void SorteArray()
        {
            int temp;
            for (int i = 0; i < _sorted_array.Length; i++)
            {
                for (int j = i + 1; j < _sorted_array.Length; j++)
                {
                    if (_sorted_array[i] > _sorted_array[j])
                    {
                        temp = _sorted_array[i];
                        _sorted_array[i] = _sorted_array[j];
                        _sorted_array[j] = temp;
                    }
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var item in _sorted_array)
            {
                yield return item;
            }
        }

        public override string? ToString()
        {
            StringBuilder result_str = new StringBuilder();
            result_str.AppendLine("Income arrays from GreatArrayMemory:");
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
