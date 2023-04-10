//This static class is created for convenient work with a text file to which the text will be written
namespace exercise_1
{
    internal static class FileWorker
    {
        private static string _file_path;

        static FileWorker()
        {
            _file_path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "SourceText.txt");
        }
        public static string[] ReadFile()
        {
            string[] readText = File.ReadAllLines(_file_path);
            return readText;
        }

        //Methot wich create file if it not exist
        public static void InitFile()
        {
            if (!File.Exists(_file_path))
            {
                string[] createText = { "Hello!", "File was created automatically.", "Fill this file with your text." };
                File.WriteAllLines(_file_path, createText);
                Console.WriteLine("File successfully created\n");
            }
            else Console.WriteLine("File already exist\n");
        }

        public static void PrintFile()
        {
            string[] test = ReadFile();
            for (int i = 0; i < test.Length; i++)
            {
                Console.WriteLine($"Line {i}:   {test[i]}");
            }
        }

        public static void WriteFile(string input_text)
        {
            File.WriteAllText(_file_path, input_text);
        }

        public static void ClearFile()
        {
            File.WriteAllText(_file_path, string.Empty);
        }
    }
}
