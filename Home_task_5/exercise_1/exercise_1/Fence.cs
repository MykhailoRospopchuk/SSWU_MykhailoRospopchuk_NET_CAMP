
using System.Text;

namespace exercise_1
{
    internal class Fence
    {
        private List<PointTree> _point_trees = new List<PointTree>();
        private List<double> _fence_length = new List<double>();

        public void AddPoint(PointTree tree, double length)
        {
            _point_trees.Add(tree);
            _fence_length.Add(length);
        }

        public bool IsTreeExist(PointTree tree)
        {
            return _point_trees.Contains(tree);
        }

        public List<PointTree> FenceTree
        {
            get { return _point_trees; }
        }
        public List<double> Length
        {
            get { return _fence_length; }
        }

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The Fence Length is: {_fence_length.Sum(),8:0.00}");
            sb.AppendLine("Fence containt Tree:");
            for(int i = 0; i < _point_trees.Count; i++)
            {
                sb.AppendLine($"{_point_trees[i].ToString()} - Length: {_fence_length[i],8:0.00}");
            }
            return sb.ToString();
        }
    }
}
