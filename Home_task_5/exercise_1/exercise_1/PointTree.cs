
namespace exercise_1
{
    internal class PointTree
    {
        private double _x_axis;
        private double _y_axis;

        public PointTree(double x_axis, double y_axis)
        {
            _x_axis = Math.Round(x_axis, 2);
            _y_axis = Math.Round(y_axis, 2);
        }

        public PointTree(string[] args)
        {
            _x_axis = Math.Round(Convert.ToDouble(args[0]), 2);
            _y_axis = Math.Round(Convert.ToDouble(args[1]), 2);
        }

        public double X_Axis
        {
            get { return _x_axis; }
            set { _x_axis = value; }
        }
        public double Y_Axis
        {
            get { return _y_axis; }
            set { _y_axis = value; }
        }

        public (double, double) GetPolarTo(PointTree income_tree, double bias_angle)
        {
            double r_polar;
            double fi_polar = 0;

            if (income_tree.X_Axis == _x_axis && income_tree.Y_Axis == _y_axis)
            {
                return (0, 0);
            }

            double x_axis = income_tree.X_Axis - _x_axis;
            double y_axis = income_tree.Y_Axis - _y_axis;

            r_polar = Math.Sqrt(Math.Pow(x_axis, 2) + Math.Pow(y_axis, 2));
            if (x_axis > 0 && y_axis >= 0) fi_polar = Math.Atan(y_axis / x_axis);
            if (x_axis > 0 && y_axis < 0) fi_polar = Math.Atan(y_axis / x_axis) + 2 * Math.PI;
            if (x_axis < 0) fi_polar = Math.Atan(y_axis / x_axis) + Math.PI;
            if (x_axis == 0 && y_axis > 0) fi_polar = Math.PI / 2;
            if (x_axis == 0 && y_axis < 0) fi_polar = Math.PI * 3 / 2;
            if (x_axis == 0 && y_axis == 0) fi_polar = 0;

            fi_polar += Math.PI - bias_angle * Math.PI/180;
            if (fi_polar > 2 * Math.PI)
            {
                fi_polar -= 2 * Math.PI;
            }
            fi_polar *= 180 / Math.PI;
            return (Math.Round(r_polar, 2), Math.Round(fi_polar, 2));
        }
    

        public string StringToWrite()
        {
            return $"{_x_axis};{_y_axis}";
        }

        public override string? ToString()
        {
            return $"X:{_x_axis,9:00.00}    Y:{_y_axis,9:00.00};";
        }
    }
}
