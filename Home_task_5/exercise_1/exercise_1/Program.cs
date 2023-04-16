using ScottPlot;
using System.Reflection.Metadata.Ecma335;

namespace exercise_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Garden garden = new Garden(60, -40, 40, "Garden_1");
            Database.SetCurrentFile("Garden");
            Database.WriteAll(garden.GardenTree);
            //Database.SetCurrentFile("Garden_bad");
            //Database.WriteAll(garden.GardenTree);

            //Database.SetCurrentFile("Garden_bad");
            //garden.GardenTree = Database.ReadAll();

            garden.GardenTree.ForEach(tree => Console.WriteLine(tree.ToString()));

            garden.FindFence();
            Console.WriteLine(garden.GardenFence.ToString());

            PlotGarden.Plot(garden.GardenTree, garden.GardenFence.FenceTree);
        }
    }
}