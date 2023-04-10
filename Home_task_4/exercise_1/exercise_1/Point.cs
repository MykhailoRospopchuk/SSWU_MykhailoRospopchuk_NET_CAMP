//This class displays a point in the text, stores the number of the line and the char
namespace exercise_1
{
    internal class Point
    {
        private int _row;
        private int _index;

        public Point(int row, int character)
        {
            this._row = row;
            this._index = character;
        }

        public int Row { get { return _row; } set { _row = value; } }
        public int Index { get { return _index; } set { _index = value; } }
    }
}
