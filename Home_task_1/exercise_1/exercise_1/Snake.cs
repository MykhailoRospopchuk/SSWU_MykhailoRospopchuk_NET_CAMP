using System.Data;
using System.Text;

namespace exercise_1
{// Молодець.
    internal class Snake
    {
        private int _row;
        private int _column;
        private int _start_number;
        private int[,] _snake_arr;

        //When changing the number of rows, a new empty matrix will be initialized
        public int Row
        {
            get { return _row; }
            set 
            {
                if (Validator(value))
                {
                    _row = value;
                    CreateEmptyArray(_row, _column);
                }
            }
        }
        //When changing the number of columns, a new empty matrix will be initialized
        public int Column
        {
            get { return _column; }
            set
            {// Метод валідування часто найкраще виносити в інший клас. 
                if (Validator(value))
                {
                    _column = value;
                    CreateEmptyArray(_row, _column);
                }
            }
        }
        public int StartNumber
        {
            get { return _start_number; }
            set { _start_number = value; }
        }

        public Snake(int rows, int columns, int start_number)
        {
            if (Validator(rows) && Validator(columns))
            {
                _row = rows;
                _column = columns;
                _start_number = start_number;
                CreateEmptyArray(rows, columns);
            }
        }

        //Initialization of an empty array
        private void CreateEmptyArray(int rows, int columns)
        {
            _snake_arr = new int[rows, columns];
        }

        //The main method of implementing the snake task in the array
        //The variable "direction" is responsible for the direction of traversal of the array: True = clockwise or False = counterclockwise
        public void SetSnakeIntoArray(bool direction)
        {
            int number = _start_number;
            int cur_row = 0;
            int cur_col = 0;
            int rows = _row;
            int cols = _column;

            // Chose direction
            if (!direction)
            {
                rows = _column;
                cols = _row;
            }

            //Make a loop until we go through all the rows and columns of the array
            while (cur_row < rows && cur_col < cols)
            {
                //Go through top or left side of array (depends from direction options)
                for (int i = cur_col; i < cols; ++i)
                {
                    if (direction) _snake_arr[cur_row, i] = number++;
                    else _snake_arr[i, cur_row] = number++;
                }
                cur_row++; //Increase the current row (column) by one

                //Go through right or bottom side of array (depends from direction options)
                for (int i = cur_row; i < rows; ++i)
                {
                    if (direction) _snake_arr[i, cols - 1] = number++;
                    else _snake_arr[cols - 1, i] = number++;
                }
                cols--; //Decrease the current column (row) by one

                //Check whether there are any row (column) that have not yet been passed
                if (cur_row < rows)
                {
                    //Go through bottom or right side of array (depends from direction options)
                    for (int i = cols - 1; i >= cur_col; --i)
                    {
                        if (direction) _snake_arr[rows - 1, i] = number++;
                        else _snake_arr[i, rows - 1] = number++;
                    }
                    rows--;//Decrease the current row (column) by one
                }
                //Check whether there are any columns (row) that have not yet been passed
                if (cur_col < cols)
                {
                    //Go through left or top side of array (depends from direction options)
                    for (int i = rows - 1; i >= cur_row; --i)
                    {
                        if (direction) _snake_arr[i, cur_col] = number++;
                        else _snake_arr[cur_col, i] = number++;
                    }
                    cur_col++;//Increase the current column (row) by one
                }
            }
        }

        //Checking the data entered by the user
        private bool Validator(int value)
        {
            if (value is <= 0)
            {
                throw new Exception(message: "User input is wrong!");
            }
            return true;
        }

        //Matrix output to the console
        public override string ToString()
        {
            StringBuilder result_str = new StringBuilder();
            for (int i = 0; i < _snake_arr.GetLength(0); i++)
            {
                for (int j = 0; j < _snake_arr.GetLength(1); j++)
                {
                    result_str.Append(_snake_arr[i, j] + " ");
                }
                result_str.Append("\n");
            }
            return result_str.ToString();
        }
    }
}
