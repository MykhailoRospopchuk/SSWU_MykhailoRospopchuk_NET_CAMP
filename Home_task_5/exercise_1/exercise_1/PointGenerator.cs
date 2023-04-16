namespace exercise_1
{
    internal static class PointGenerator
    {
        public static List<PointTree> GenerateGarden(int number_tree, double min_value, double max_value)
        {
            List<PointTree> result_garden = new List<PointTree>();
            Random random = new Random();
            double x_point;
            double y_point;
            for (int i = 0; i < number_tree; i++)
            {
                x_point = random.NextDouble() * (max_value - min_value) + min_value;
                y_point = random.NextDouble() * (max_value - min_value) + min_value;
                result_garden.Add(new PointTree(x_point, y_point));
            }
            return result_garden;
        }
    }
}
