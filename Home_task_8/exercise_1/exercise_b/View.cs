//This class performs functions of outputting information about the current state of traffic lights to the console.
using System.Text;

namespace exercise_b
{
    internal static class View
    {
        public static event Action<int> ChangingTrafficOrder;
        public static void PrintState(dynamic[] traffic_lights, TimeSpan ts)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string timer = String.Format("{0:00}:{1:00}.{2:00} ", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.Write(timer);
            string color = "";
            StringBuilder sb = new StringBuilder();
            foreach (var light in traffic_lights)
            {
                int state = light.State;
                List<int> current = state.ToString().Select(digit => int.Parse(digit.ToString())).ToList();
                foreach (var item in current)
                {
                    switch (item)
                    {
                        case 1:
                            sb.Append(" Red ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case 2:
                            sb.Append(" Yellow ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case 3:
                            sb.Append(" Green ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        default:
                            break;
                    }
                }
                if (current.Count != 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }

                color = sb.ToString();
                sb.Clear();
                Console.Write($" {light.ID}-{light.Number}-{color}");
            }
            
            Console.WriteLine("\n");  
        }

        public static void PrintChangeState(int income_arr)
        {
            ChangingTrafficOrder?.Invoke(income_arr);
        }
    }
}
