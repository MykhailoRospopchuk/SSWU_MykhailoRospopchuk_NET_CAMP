//This class is created to work with two-dimensional arrays that we take from the Cube.
using System.Text;
namespace exercise_3
{
    internal class EdgeCub
    {
        private readonly int _size;
        private int[,] _array;

        protected EdgeCub(int size)
        {
            this._size = size;
            this._array = new int[size, size];
        }

        protected EdgeCub(int[,] income_array)
        {
            this._array = income_array;
            this._size = income_array.GetLength(0);
        }
        //Searches for empty points in a two-dimensional array that do not lie on the boundary
        protected List<Point> FindWayPoint(int[,] incom_array = null)
        {
            int[,] current;

            if (incom_array == null) current = this._array;
            else current = incom_array;

            List<Point> way = new List<Point>();
            for (int i = 1; i < _size - 1; i++)
            {
                for (int j = 1; j < _size - 1; j++)
                {
                    if (current[i, j] == 0) way.Add(new Point(i, j));
                }
            }
            return way;
        }

        //Accepts a list of coordinates of points that must be checked in the array for the presence of an empty space in the specified coordinates
        protected List<Point> CheckWayPoint(List<Point> waypoints, int[,] incom_array = null)
        {
            int[,] current;
            List<Point> waypoints_list = new List<Point>();

            if (incom_array == null) current = this._array;
            else current = incom_array;

            waypoints.ForEach(item => {if (current[item.X, item.Y] == 0) waypoints_list.Add(new Point(item.X, item.Y));});
            return waypoints_list;
        }
        //Searches in a two-dimensional array for empty points that lie on the border from the left
        protected List<Point> FindLeftDiagonalEntry(int[,] incom_array = null)
        {
            int[,] current;

            if (incom_array == null) current = this._array;
            else current = incom_array;

            List<Point> entry = new List<Point>();
            for (int i = 1; i < _size - 1; i++)
            {
                if (current[i, 0] == 0) entry.Add(new Point(i, 0));
                if (current[0, i] == 0) entry.Add(new Point(0, i));
            }
            return entry;
        }
        //Searches in a two-dimensional array for empty points that lie on the border from the right
        protected List<Point> FindRightDiagonalEntry(int[,] incom_array = null)
        {
            int[,] current;

            if (incom_array == null) current = this._array;
            else current = incom_array;

            List<Point> entry = new List<Point>();
            for (int i = 1; i < _size - 1; i++)
            {
                if (current[0, i] == 0) entry.Add(new Point(0, i));
                if (current[i, _size - 1] == 0) entry.Add(new Point(i, _size - 1));
            }
            return entry;
        }
        //Gets a list of points and checks if they are the start of a diagonal hole from the left
        protected Point CheckWayLeftDiagonalPoint(Point entry_point, int[,] incom_array = null)
        {
            int[,] current;
            if (incom_array == null) current = this._array;
            else current = incom_array;
            Point end_point = entry_point;
            bool marker = true;
            
            for (int i = entry_point.X, j = entry_point.Y ; i < _size && j < _size; i++, j++)
            {
                if (current[i, j] != 0)
                {
                    marker = false;
                    break;
                }
                end_point = new Point(i, j);
            }
            if (marker) return end_point;
            else return null;
        }
        //Gets a list of points and checks if they are the start of a diagonal hole from the right
        protected Point CheckWayRightDiagonalPoint(Point entry_point, int[,] incom_array = null)
        {
            int[,] current;
            if (incom_array == null) current = this._array;
            else current = incom_array;
            Point end_point = entry_point;
            bool marker = true;

            for (int i = entry_point.X, j = entry_point.Y; i < _size && j >= 0; i++, j--)
            {
                if (current[i, j] != 0)
                {
                    marker = false;
                    break;
                }
                end_point = new Point(i, j);
            }
            if (marker) return end_point;
            else return null;
        }
        
        public override string ToString()
        {
            StringBuilder result_str = new StringBuilder();
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    result_str.Append(_array[i, j] + " ");
                }
                result_str.Append("\n");
            }
            return result_str.ToString();
        }
    }
}
