using System;
using System.Text;

namespace exercise_4
{
    internal class Tensor
    {
        private int[] _indexes;
        private int[] _tensor;
        private int[] _multipliers;

        public Tensor(int dimension)
        {
            if (dimension < 0)
            {
                throw new ArgumentOutOfRangeException("dimension", dimension, "Dimension can't be less than 0");
            }
            if (dimension == 1)
            {
                this._tensor = new int[dimension];
            }
            this._indexes = new int[dimension-1];
        }

        public void InitializationTensor(params int[] indexes)
        {
            if (indexes == null)
            {
                throw new ArgumentNullException(nameof(indexes));
            }
            int length = indexes.Length;
            this._indexes = indexes;
            this._tensor = new int[length];
            this._multipliers = GetMultipliers();
        }

        public void SetValue(int value, params int[] index)
        {
            if (index.Length != _indexes.Length)
            {
                throw new ArgumentOutOfRangeException("index", index, "Incorrect element address indices are specified");
            }
            try
            {
                int index_in_tensor = GetIndexTensor(index);
                this._tensor[index_in_tensor] = value;
            }
            catch (Exception e)
            {
                throw new ArithmeticException(e.Message);
            }
        }

        public int GetValue(params int[] index)
        {
            if (index.Length != _indexes.Length)
            {
                throw new ArgumentOutOfRangeException("index", index, "Incorrect element address indices are specified");
            }
            try
            {
                int index_in_tensor = GetIndexTensor(index);
                int value = this._tensor[index_in_tensor];
                return value;
            }
            catch (Exception e)
            {
                throw new ArithmeticException(e.Message);
            }
        }

        public int this[params int[] index]
        {
            get { return GetValue(index); }
            set { SetValue(value, index); }
        }

        private int GetIndexTensor(int[] input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            int indexes = 0;
            int[] mult = _multipliers;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                indexes += input[i] * mult[i];
            }
            return indexes;
        }

        private int[] GetMultipliers()
        {
            int[] multipliers = new int[_indexes.Length];
            multipliers[_indexes.Length - 1] = 1;
            for (int i = _indexes.Length - 2; i >= 0; i--)
            {
                multipliers[i] = _indexes[i + 1] * multipliers[i + 1];
            }
            return multipliers;
        }

        //Matrix output to the console
        public override string ToString()
        {
            StringBuilder result_str = new StringBuilder();
            for (int j = 0; j < _tensor.Length; j++)
            {
                result_str.Append(_tensor[j] + " ");
            }
            result_str.Append("\n");
            return result_str.ToString();
        }
    }
}
