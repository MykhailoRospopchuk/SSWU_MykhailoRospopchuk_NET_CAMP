//This static class is used to work with text files in which the results of the work will be written
namespace exercise_1
{
    internal static class Database
    {
        private static string _system_path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Garden.txt");

        public static void SetCurrentFile(string file_name = "Garden")
        {
            _system_path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"{file_name}.txt");
            if (!File.Exists(_system_path))
            {
                using (FileStream fs = File.Create(_system_path));
            }
        }

        public static void WriteAll(List<PointTree> garden)
        {
            if (File.Exists(_system_path))
            {
                using (StreamWriter file = new StreamWriter(_system_path))
                {
                    garden.ForEach(tree => file.WriteLine(tree.StringToWrite()));  
                }
            }
        }

        public static List<PointTree> ReadAll()
        {
            List<PointTree> garden = new List<PointTree>();

            if (File.Exists(_system_path))
            {
                string line = "";
                using (StreamReader file = new StreamReader(_system_path))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        garden.Add(new PointTree(line.Split(';')));
                    }
                }
            }
            return garden;
        }
    }
}
