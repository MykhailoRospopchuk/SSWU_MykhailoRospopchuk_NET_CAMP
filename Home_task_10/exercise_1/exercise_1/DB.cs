//A static class that simulates working with a database.
//Reads, writes and deletes information about registered card brands and input card data from text files
namespace exercise_1
{
    internal static class DB
    {
        //Stores path to text files: card brands and cards
        internal static class PathData
        {
            public readonly static string _card_brand_path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, $"card_brand.txt");
            public readonly static string _card_income_path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, $"card_income.txt");
        }

        //If there are no files, it creates two new empty ones
        static DB()
        {
            if (!File.Exists(PathData._card_brand_path))
            {
                using (FileStream fs = File.Create(PathData._card_brand_path));
            }
            if (!File.Exists(PathData._card_income_path))
            {
                using (FileStream fs = File.Create(PathData._card_income_path));
            }
        }

        //Reads all lines from the file specified by the path
        public static List<string> GetAllLine(string path)
        {
            List<string> result = new List<string>();

            if (File.Exists(path))
            {
                string line = "";
                using (StreamReader file = new StreamReader(path))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        result.Add(line);
                    }
                }
            }
            return result;
        }

        //Writes a line to the file specified by the path
        public static void WriteLine(string line, string path)
        {
            if (File.Exists(path))
            {
                using (StreamWriter file = new StreamWriter(path, true))
                {
                    file.WriteLine($"{line}");
                }
            }
        }

        //Cleans the file specified by the path
        public static void ClearFile(string path)
        {
            if (File.Exists(path))
            {
                using (StreamWriter file = new StreamWriter(path))
                {
                    file.WriteLine(string.Empty);
                }
            }
        }
    }
}
