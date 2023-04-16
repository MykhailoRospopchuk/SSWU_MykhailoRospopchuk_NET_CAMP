
namespace exercise_1
{
    internal static class PlotGarden
    {
        private static string _system_path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "plot.png");

        public static void SetNewPlotPath(string plotPath)
        {
            _system_path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"{plotPath}.png");
        }

        public static void Plot(List<PointTree> garden, List<PointTree> fences)
        {
            double min_axis_x = garden[0].X_Axis;
            double min_axis_y = garden[0].Y_Axis;
            double max_axis_x = garden[0].X_Axis;
            double max_axis_y = garden[0].Y_Axis;

            garden.ForEach(g => {
                min_axis_x = g.X_Axis < min_axis_x ? g.X_Axis : min_axis_x;
                min_axis_y = g.Y_Axis < min_axis_y ? g.Y_Axis : min_axis_y;
                max_axis_x = g.X_Axis > max_axis_x ? g.X_Axis : max_axis_x;
                max_axis_y = g.Y_Axis > max_axis_y ? g.Y_Axis : max_axis_y;
            });

            List<double> dataX = new List<double>();
            List<double> dataY = new List<double>();
            List<string> labels = new List<string>();
            garden.ForEach(g => {
                dataX.Add(Math.Round(g.X_Axis, 2));
                dataY.Add(Math.Round(g.Y_Axis, 2));
                labels.Add($"{g.X_Axis:0.00};{g.Y_Axis:0.00}");
            });

            List<double> fenceX = new List<double>();
            List<double> fenceY = new List<double>();
            fences.ForEach(f =>
            {
                fenceX.Add(Math.Round(f.X_Axis, 2));
                fenceY.Add(Math.Round(f.Y_Axis, 2));
            });

            double border_x = (max_axis_x - min_axis_x) * 0.2;
            double border_y = (max_axis_y - min_axis_y) * 0.2;

            var plt = new ScottPlot.Plot(800, 800);
            plt.SetAxisLimits(min_axis_x - border_x, max_axis_x + border_x, min_axis_y - border_y, max_axis_y + border_y);
            plt.AddScatter(fenceX.ToArray(), fenceY.ToArray());
            var sp = plt.AddScatter(dataX.ToArray(), dataY.ToArray(), lineWidth: 0, markerSize: 10);
            sp.DataPointLabels = labels.ToArray();
            sp.DataPointLabelFont.Size = 14;
           
            plt.SaveFig(_system_path);
        }
    }
}
