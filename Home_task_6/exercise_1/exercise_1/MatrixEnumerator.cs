using System.Collections;
using System.Text;

namespace exercise_1
{
    public class MatrixEnumerator : IEnumerable
    {
        private readonly int[,] _matrix;
        private readonly int _dim;
        private readonly int _diag;

        public MatrixEnumerator(int[,] income_matrix)
        {
            _matrix = (int[,])income_matrix.Clone();
            _dim = income_matrix.GetLength(0);
            _diag = _dim * 2;
        }

        public IEnumerator GetEnumerator()
        {
            //Return first element
            yield return _matrix[0, 0];

            //Variable "direction"
            //  if True - go from Top to Down
            //  if False - go from Down to Top
            bool direction = true;

            //Variable "side"
            //Equals 0 if before main diagonal and equals dimension -1 if after main diagonal
            int side = 0;

            //Return element before main diagonal
            for (int diag = 1; diag < _diag / 2; diag++)
            {
                int row = diag;
                int col = side;
                if (!direction)
                {
                    (col, row) = (row, col);
                }
                while (row >= 0 && col < _dim && col >= 0 && row < _dim)
                {
                    yield return _matrix[row, col];
                    if (direction)
                    {
                        --row;
                        ++col;
                    }
                    else
                    {
                        ++row;
                        --col;
                    }

                }
                direction = !direction;
            }

            //Return element after main diagonal
            side = _dim - 1;
            for (int diag = 1; diag < _diag / 2; diag++)
            {
                int row = side;
                int col = diag;
                if (!direction)
                {
                    (col, row) = (row, col);
                }
                while (row >= 0 && col < _dim && col >= 0 && row < _dim)
                {
                    yield return _matrix[row, col];
                    if (direction)
                    {
                        --row;
                        ++col;
                    }
                    else
                    {
                        ++row;
                        --col;
                    }
                }
                direction = !direction;
            }
        }

        public override string? ToString()
        {
            StringBuilder result_str = new StringBuilder();
            result_str.AppendLine("Income matrix:");
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    result_str.Append( $"{_matrix[i, j],-2} ");
                }
                result_str.Append("\n");
            }
            return result_str.ToString();
        }
    }
}
