using System.Text;
namespace exercise_2
{
    internal static class Validator
    {
        public static (string str_source, string str_found) InputSearched()
        {
            bool marker = true;
            (bool, string) result;
            string source = "";
            string found = "";
            Console.WriteLine("Hello, World! Enter the values in sequence: Source string, Searched string");
            while (marker)
            {
                Console.Write("Source: ");
                source = Console.ReadLine();
                Console.Write("Searched: ");
                found = Console.ReadLine();
                result = IsValidSearched(source, found);
                if (result.Item1) marker = false;
                else marker = true;
                Console.WriteLine(result.Item2);
            }

            return (source, found);
        }
        public static (bool, string) IsValidSearched(string str_source, string str_found)
        {
            bool marker = true;
            StringBuilder sb = new StringBuilder();
            if (str_found.Length > str_source.Length)
            {
                String warning = "WARNING! Searched string can't be bigger than Source string";
                sb.AppendLine(warning);
                marker = false;
            }
            if (str_found.Length == 0)
            {
                String warning = "WARNING! Searched string can't be empty";
                sb.AppendLine(warning);
                marker = false;
            }
            if (str_source.Length == 0)
            {
                String warning = "WARNING! Source string can't be empty";
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

