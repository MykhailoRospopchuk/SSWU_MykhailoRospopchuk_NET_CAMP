//This class describes a Way on a two-dimensional array.
//Accepts the start and end Point, and the number of the two-dimensional array it has in the cube
namespace exercise_3
{
    internal class Way
    {
        private int _edge;
        private Point _entry;
        private Point _out;

        public Way(int edge_in, Point entry_in, Point out_in)
        {
            _edge = edge_in;
            _entry = entry_in;
            _out = out_in;
        }

        public int Edge { get { return _edge; } }
        public Point Entry { get { return _entry; } }
        public Point Out { get { return _out; } }
    }
}
