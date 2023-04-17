//This class is used to model a garden.
//Stores a list of trees, a fence and the name of the garden
using System.Text;

namespace exercise_1
{
    internal class Garden
    {
        private List<PointTree> _pointTrees = new List<PointTree>();
        private Fence _fences = new Fence();
        private string _garden_name = "Garden";

        public List<PointTree> GardenTree 
        { 
            get { return _pointTrees; }
            set { _pointTrees = value; }
        }

        public Fence GardenFence
        {
            get { return _fences; }
            set { _fences = value; }
        }

        public string GardenName
        {
            get { return _garden_name; }
            set { _garden_name = value; }
        }

        public Garden(int number_tree, double min_value, double max_value, string garden_name = "Garden")
        {
            _pointTrees = PointGenerator.GenerateGarden(number_tree, min_value, max_value);
            _garden_name = garden_name;
        }

        //The method causes the search for the garden fence to be performed
        public void FindFence()
        {
            _fences = BuildFence();
        }

        //The method performs a fence search for the tree list of the given instance of the garden
        private Fence BuildFence()
        {
            //Calculation of the coordinates of the starting point, which lies outside the trees
            double min_axis_x = _pointTrees[0].X_Axis;
            double min_axis_y = _pointTrees[0].Y_Axis;
            double max_axis_x = _pointTrees[0].X_Axis;
            double max_axis_y = _pointTrees[0].Y_Axis;

            _pointTrees.ForEach(g =>
            {
                min_axis_x = g.X_Axis < min_axis_x ? g.X_Axis : min_axis_x;
                min_axis_y = g.Y_Axis < min_axis_y ? g.Y_Axis : min_axis_y;
                max_axis_x = g.X_Axis > max_axis_x ? g.X_Axis : max_axis_x;
                max_axis_y = g.Y_Axis > max_axis_y ? g.Y_Axis : max_axis_y;
            });

            double init_x = min_axis_x - (max_axis_x - min_axis_x) * 0.2;
            double init_y = min_axis_y - (max_axis_y - min_axis_y) * 0.2;

            //Finding the first tree that will be the beginning of the fence.
            //Lies closest to the starting point outside the trees
            PointTree first_tree = new PointTree(0, 0);
            PointTree zero_tree = new PointTree(init_x, init_y);
            (double radius, double angle) = zero_tree.GetPolarTo(_pointTrees[0], 180);
            (double temp_radius, double temp_angle) = (0, 0);
            _pointTrees.ForEach(tree =>
            {
                (temp_radius, temp_angle) = zero_tree.GetPolarTo(tree, 180);
                if (temp_radius <= radius)
                {
                    first_tree = tree;
                    radius = temp_radius;
                    angle = temp_angle;
                }
            });

            //Creating an instance of a fence
            Fence fence_garden = new Fence();
            //Inserting the initial tree into the fence instance
            fence_garden.AddPoint(first_tree, 0);

            //Initialization of initial values
            (temp_radius, temp_angle) = first_tree.GetPolarTo(_pointTrees[0], angle);
            (double curr_radius, double curr_angle) = (0, 0);
            PointTree current_tree = first_tree;

            //Search for trees that will be points of the fence
            bool marker = true;
            while (marker)
            {
                _pointTrees.ForEach(tree =>
                {
                    if (tree.X_Axis != zero_tree.X_Axis || tree.Y_Axis != zero_tree.Y_Axis)
                    {
                        (temp_radius, temp_angle) = first_tree.GetPolarTo(tree, angle);
                        if (temp_angle > curr_angle)
                        {
                            current_tree = tree;
                            curr_angle = temp_angle;
                            curr_radius = temp_radius;
                        }
                    }
                });

                zero_tree = first_tree;
                first_tree = current_tree;

                //If the fence already has an instance of the found tree, the search ends
                if (fence_garden.IsTreeExist(first_tree))
                {
                    fence_garden.AddPoint(first_tree, curr_radius);
                    marker = false;
                }
                else fence_garden.AddPoint(first_tree, curr_radius);

                (radius, angle) = zero_tree.GetPolarTo(current_tree, 180);
                (curr_radius, curr_angle) = (0, 0);
            }
            return fence_garden;
        }

        public static bool operator ==(Garden garden_1, Garden garden_2)
        {
            if (garden_1._fences.GetLength.Sum() == garden_2._fences.GetLength.Sum())
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Garden garden_1, Garden garden_2)
        {
            if (garden_1._fences.GetLength.Sum() != garden_2._fences.GetLength.Sum())
            {
                return true;
            }
            return false;
        }

        public static bool operator >(Garden garden_1, Garden garden_2)
        {
            if (garden_1._fences.GetLength.Sum() > garden_2._fences.GetLength.Sum())
            {
                return true;
            }
            return false;
        }

        public static bool operator <(Garden garden_1, Garden garden_2)
        {
            if (garden_1._fences.GetLength.Sum() < garden_2._fences.GetLength.Sum())
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Garden Name {_garden_name}.\n{_garden_name} has this trees:");
            _pointTrees.ForEach(tree => sb.AppendLine(tree.ToString()));
            sb.AppendLine($"{_garden_name} has fence:");
            sb.AppendLine(_fences.ToString());
            return sb.ToString();
        }
    }
}
