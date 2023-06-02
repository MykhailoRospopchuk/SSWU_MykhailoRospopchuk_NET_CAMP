
namespace exercise_1
{
    internal static class DB
    {
        internal static class PathData
        {
            public readonly static string _bank_brand_path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, $"bank_brand.txt");
            public readonly static string _card_income_path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, $"card_income.txt");
        }

        public static void InitDB()
        {
            if (!File.Exists(PathData._bank_brand_path))
            {
                using (FileStream fs = File.Create(PathData._bank_brand_path));
            }
            if (!File.Exists(PathData._card_income_path))
            {
                using (FileStream fs = File.Create(PathData._card_income_path));
            }
        }

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

        public static void WriteLine(string line, string path)
        {
            if (File.Exists(path))
            {
                using (StreamWriter file = new StreamWriter(path, true))
                {
                    file.WriteLine(line);
                }
            }
        }

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
