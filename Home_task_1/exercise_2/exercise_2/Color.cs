using System.Text;

namespace exercise_2
{
    internal class Color
    {
        private int _row;
        private int _column;
        private int[,] _color_arr;

        public Color(int row, int column)
        {
            if (Validator(row) && Validator(column))
            {
                _row = row;
                _column = column;
                _color_arr = new int[row, column];
            }
            
        }

        //Filling the array with colors
        public void GenerateColor(int from, int to)
        {
            if (Validator(from) && Validator(to))
            {
                Random random = new Random();
                for (int i = 0; i < _row; i++)
                {
                    for (int j = 0; j < _column; j++)
                    {
                        _color_arr[i, j] = random.Next(from, to);
                    }
                }
            }
        }

        //The main method finging color line
        public void ColorLine()
        {
            int lenght = 0;
            int[] begin_index = new int[2];
            int[] end_index = new int[2];
            int[] begin_temp = new int[2];


            for (int i = 0; i < _row; i++)
            {
                begin_temp[0] = i;
                begin_temp[1] = 0;
                for (int j = 1; j < _column; j++)
                {// Не оптимально
                    if (_color_arr[begin_temp[0], begin_temp[1]] == _color_arr[i, j])
                    {
                        if (j - begin_temp[1] > lenght)
                        {
                            begin_index[0] = begin_temp[0];
                            begin_index[1] = begin_temp[1];
                            end_index[0] = i;
                            end_index[1] = j;
                            lenght = end_index[1] - begin_index[1];
                        }
                    }
                    else
                    {
                        begin_temp[0] = i;
                        begin_temp[1] = j;
                    }
                }
            }
            lenght++;
            // роздрук в цьому методі не доречний. Результат слід повертати як параметри методу.
            Console.WriteLine("Color is: {0}", _color_arr[begin_index[0], begin_index[1]]);
            Console.WriteLine("Lenght = {0}", lenght);
            Console.WriteLine("Begin index: [{0}, {1}]", begin_index[0], begin_index[1]);
            Console.WriteLine("End index: [{0}, {1}]", end_index[0], end_index[1]);
        }



        //Checking the data entered by the user
        private bool Validator(int value)
        {
            if (value is < 0)
            {
                throw new Exception(message: "User input is wrong!");
            }
            return true;
        }

        //Matrix output to the console
        public override string ToString()
        {
            StringBuilder result_str = new StringBuilder();
            for (int i = 0; i < _color_arr.GetLength(0); i++)
            {
                for (int j = 0; j < _color_arr.GetLength(1); j++)
                {
                    result_str.Append(_color_arr[i, j] + " ");
                }
                result_str.Append("\n");
            }
            return result_str.ToString();
        }
    }
}
