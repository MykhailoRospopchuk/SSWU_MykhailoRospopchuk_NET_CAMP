using ScottPlot;

namespace exercise_1
{//Mykhailo	Rospopchuk			95	19	19	90	85	99	100	112,8. Вітаю Вас в 2 турі.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //Creating an instance of a garden named "Garden_1" that contains 15 trees at Cartesian coordinates from -40 to 40
            Garden garden_1 = new Garden(15, -40, 40, "Garden_1");
            //Finding the fence
            garden_1.FindFence();
            //Writing a list of tree coordinates to a text file
            Database.SetCurrentFile("Garden_1");
            Database.WriteAll(garden_1.GardenTree);
            //Writing the list of coordinates of trees that are points of the fence in a text file
            Database.SetCurrentFile("Garden_1_Fence");
            Database.WriteAll(garden_1.GardenFence.GetFenceTree);
            //Print to a file a graphic display of a garden with trees and a fence
            PlotGarden.SetNewPlotPath(garden_1.GardenName);
            Console.WriteLine(garden_1.ToString());
            PlotGarden.Plot(garden_1.GardenTree, garden_1.GardenFence.GetFenceTree);

            //Creating an instance of a garden named "Garden_2" that contains 65 trees at Cartesian coordinates from -540 to 540
            Garden garden_2 = new Garden(65, -540, 540, "Garden_2");
            //Finding the fence
            garden_2.FindFence();
            //Writing a list of tree coordinates to a text file
            Database.SetCurrentFile("Garden_2");
            Database.WriteAll(garden_2.GardenTree);
            //Writing the list of coordinates of trees that are points of the fence in a text file
            Database.SetCurrentFile("Garden_2_Fence");
            Database.WriteAll(garden_2.GardenFence.GetFenceTree);
            //Print to a file a graphic display of a garden with trees and a fence
            PlotGarden.SetNewPlotPath(garden_2.GardenName);
            Console.WriteLine(garden_2.ToString());
            PlotGarden.Plot(garden_2.GardenTree, garden_2.GardenFence.GetFenceTree);


            //Creating an instance of a garden named "Garden_3" that contains 3 trees at Cartesian coordinates from 0 to 50
            Garden garden_3 = new Garden(3, 0, 50, "Garden_3");
            garden_3.FindFence();
            Database.SetCurrentFile("Garden_3");
            Database.WriteAll(garden_3.GardenTree);
            Database.SetCurrentFile("Garden_3_Fence");
            Database.WriteAll(garden_3.GardenFence.GetFenceTree);
            PlotGarden.SetNewPlotPath(garden_3.GardenName);
            Console.WriteLine(garden_3.ToString());
            PlotGarden.Plot(garden_3.GardenTree, garden_3.GardenFence.GetFenceTree);

            //Creating an instance of a garden named "Garden_4" that contains 4 trees at Cartesian coordinates from 0 to 50
            Garden garden_4 = new Garden(4, 0, 50, "Garden_4");
            garden_4.FindFence();
            Database.SetCurrentFile("Garden_4");
            Database.WriteAll(garden_4.GardenTree);
            Database.SetCurrentFile("Garden_4_Fence");
            Database.WriteAll(garden_4.GardenFence.GetFenceTree);
            PlotGarden.SetNewPlotPath(garden_4.GardenName);
            Console.WriteLine(garden_4.ToString());
            PlotGarden.Plot(garden_4.GardenTree, garden_4.GardenFence.GetFenceTree);

            Console.WriteLine(garden_1 == garden_2);
            Console.WriteLine(garden_1 != garden_2);
            Console.WriteLine(garden_3 > garden_2);
            Console.WriteLine(garden_4 < garden_2);
        }
    }
}
