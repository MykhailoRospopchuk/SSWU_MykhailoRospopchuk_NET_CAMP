// This class models the current array element. Stores values and indexes.
namespace exercise_2
{
    internal class Point
    {
        private int _value;
        private List<(int, int)> _coordinate = new List<(int, int)>();

        public Point(int value, int i_coordinate, int j_coordinate)
        {
            _value = value;
            _coordinate.Add((i_coordinate, j_coordinate));
        }

        public void AddCoordinate(int value, int i_coordinate, int j_coordinate)
        {
            if (_value == value)
            {
                //If the value of the point coincides, then we add the coordinates
                _coordinate.Add((i_coordinate, j_coordinate));
            }
            else
            {
                //If the value of the point does not match, then we clear the list of coordinates and write new ones.
                //Since a new point is passed to the method argument
                _value = value;
                _coordinate.Clear();
                _coordinate.Add((i_coordinate, j_coordinate));
            }
        }

        public bool CheckCoordinate(int value, int i_coordinate, int j_coordinate)
        {
            //Check whether the point passed to the method argument is the current point
            if (_value == value && _coordinate.Contains((i_coordinate, j_coordinate)))
            {
                return true;
            }
            return false;
        }
    }
}
