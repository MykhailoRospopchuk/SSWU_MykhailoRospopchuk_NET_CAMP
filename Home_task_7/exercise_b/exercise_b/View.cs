//This class performs functions of outputting information about the current state of traffic lights to the console.
namespace exercise_b
{
    internal static class View
    {
        public static event Action<int> ChangingTrafficOrder;
        public static void PrintState(dynamic[] traffic_lights, TimeSpan ts)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string timer = String.Format("{0:00}:{1:00}.{2:00}: ", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.Write(timer);
            foreach (var light in traffic_lights)
            {
                switch (light.Color)
                {
                    case "Red":
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "Yellow":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case "Green":
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    default:
                        break;
                }
                Console.Write($"{light.Number}-{light.Color,-7}");
            }
            Console.WriteLine("\n");  
        }

        public static void PrintChangeState(int income_arr)
        {
            ChangingTrafficOrder?.Invoke(income_arr);
        }
    }
}
