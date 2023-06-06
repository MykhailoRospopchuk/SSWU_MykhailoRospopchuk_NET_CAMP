//The class is responsible for reading and writing information to a file
using System.Reflection;

namespace exercise_2
{
    internal static class DB
    {
        //A nested class that stores the path to files
        internal static class PathData
        {
            public readonly static string _type_path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, $"type_product.txt");
            public readonly static string _features_path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, $"features_product.txt");
            public readonly static string _product_path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, $"product.txt");
            public readonly static string _delivery_path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, $"delivery_product.txt");
        }

        //Initialization of all files if they were not previously created
        static DB()
        {
            Type type = typeof(PathData);
            FieldInfo[] fields = type.GetFields();
            foreach (var item in fields)
            {
                string curr_path = (string?)item.GetValue(null);
                if (!File.Exists(curr_path))
                {
                    using (FileStream fs = File.Create(curr_path));
                }
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

        //Reads one lines from the file specified by the path
        public static string GetLine(int id, string path)
        {
            int count = 1;
            if (File.Exists(path))
            {
                string line = "";
                using (StreamReader file = new StreamReader(path))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if (count == id)
                        {
                            return line;
                        }
                        count++;
                    }
                }
            }
            return null;
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
