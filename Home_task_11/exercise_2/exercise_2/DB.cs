// Static class for forking with .txt files.
namespace exercise_2
{
    internal static class DB
    {
        //A nested class that stores the path to files
        internal static class PathData
        {
            public readonly static string _init_path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, $"init.txt");
            public readonly static string _temp_path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName);
        }

        //Initialization of all files if they were not previously created
        static DB()
        {
            if (File.Exists(PathData._init_path))
            {
                DeleteFile(PathData._init_path);
                
            }
            using (FileStream fs = File.Create(PathData._init_path)) ;
        }

        //Create set of temp .txt files 
        public static void InitTempPath(int number)
        {
            for (int i = 0; i < number; i++)
            {
                string? curr_path = Path.Combine(PathData._temp_path, $"temp{i}.txt");
                if (!File.Exists(curr_path))
                {
                    using (FileStream fs = File.Create(curr_path));
                }
            }
        }

        public static void Init()
        {
            Console.WriteLine("DB Init");
        }

        //Reads all lines from the file specified by the path
        public static int GetCount(string path)
        {
            int counter = 0;
            if (File.Exists(path))
            {
                using (var reader = File.OpenText(path))
                {
                    while (reader.ReadLine() != null)
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        //Reads all lines in in the specified range from the file specified by the path
        public static int[] GetRangeLine(string path, int begin, int end)
        {
            List<string> result = new List<string>();
            int counter = 1;
            if (File.Exists(path))
            {
                string line = "";
                using (StreamReader file = new StreamReader(path))
                {
                    while ((line = file.ReadLine()) != null && counter <= end)
                    {
                        if (counter >= begin)
                        {
                            result.Add(line);
                        }
                        counter++;
                    }
                }
            }
            int[] res_array = Array.ConvertAll(result.ToArray(), Convert.ToInt32);
            return res_array;
        }
        //Reads all lines from the file specified by the path
        public static int[] GetAllLine(string path)
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
            int[] res_array = Array.ConvertAll(result.ToArray(), Convert.ToInt32);
            return res_array;
        }

        //Writes all line to the file specified by the path
        public static void WriteAllLine(int[] line, string path)
        {
            if (File.Exists(path))
            {
                using (StreamWriter file = new StreamWriter(path, true))
                {
                    foreach (var item in line)
                    {
                        file.WriteLine($"{item}");
                    }
                    
                }
            }
        }

        //Delete specified file
        public static void DeleteFile(string path)
        {
            if (File.Exists(path)) // Check if file exists
            {
                // Delete the file
                File.Delete(path);
            }
        }
    }
}
