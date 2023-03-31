using System.Text;
namespace WaterTower
{
    internal static class Validator
    {
        
        public static (int consumption, int power, int max_level, int current_level) Input()
        {
            bool marker = true;
            (bool, string) result;
            int consumption = 0;
            int power = 0;
            int max_level = 0;
            int current_level = 0;
            Console.WriteLine("Hello, World! Enter the values in sequence: Consumption, Power, Max level, Current level");
            while (marker)
            {
                Console.Write("consumption: ");
                consumption = Convert.ToInt32(Console.ReadLine());
                Console.Write("Power: ");
                power = Convert.ToInt32(Console.ReadLine());
                Console.Write("Max level: ");
                max_level = Convert.ToInt32(Console.ReadLine());
                Console.Write("Current level: ");
                current_level = Convert.ToInt32(Console.ReadLine());
                result = IsValidUserInput(consumption, power, max_level, current_level);
                if (result.Item1) marker = false;
                else marker = true;
                Console.WriteLine(result.Item2);
            }
            
            return (consumption, power, max_level, current_level);
        }
        public static (bool, string) IsValidUserInput(int consumption, int power, int max_level, int current_level)
        {
            bool marker = true;
            StringBuilder sb = new StringBuilder();
            if (current_level > max_level)
            {
                String warning = String.Format("WARNING! Current level {0} can't be bigger than max level of water in tower {1}", current_level, max_level);
                sb.AppendLine(warning);
                marker = false;
            }
            if (consumption < 0 || power < 0 || max_level <= 0 || current_level <= 0)
            {
                String warning = "WARNING! All input value can't be negative";
                sb.AppendLine(warning);
                marker = false;
            }
            if (consumption > max_level)
            {
                String warning = "WARNING! Consumption can't be bigger than Tower can hold water";
                sb.AppendLine(warning);
                marker = false;
            }
            if (power > max_level)
            {
                String warning = "WARNING! Pump Power can't be bigger than Tower can hold water";
                sb.AppendLine(warning);
                marker = false;
            }
            if (marker)
            {
                sb.AppendLine("All input values are correct");
            }
            return (marker, sb.ToString());
        }
    }
}
