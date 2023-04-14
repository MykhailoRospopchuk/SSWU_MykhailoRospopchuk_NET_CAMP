
namespace exercise_3
{
    internal static class Database
    {
        private static List<string> _quarter_files = new List<string>();
        private static string _system_path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"system_path.txt");
        private static string _current_quarter = "";
        private static string _current_file_record = "";
        private static string _current_file_quarter = "";

        static Database()
        {
            if (!File.Exists(_system_path))
            {
                using (FileStream fs = File.Create(_system_path));
            }
            ReadSystem();
        }

        private static void ReadSystem()
        {
            List<string> result = new List<string>();

            if (File.Exists(_system_path))
            {
                string line = "";
                using (StreamReader file = new StreamReader(_system_path))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if (!result.Contains(line))
                        {
                            result.Add(line);
                        }
                    }
                }
            }
            _quarter_files = result;
        }

        private static void WriteSystem(string income)
        {
            if (File.Exists(_system_path))
            {
                using (StreamWriter file = new StreamWriter(_system_path, true))
                {
                    file.WriteLine(income);
                }
            }
        }

        public static void SetQuarterFileName(EnergyQuarter income_quarter, DateTime year)
        {
            string current = $"{year.ToString("yyyy")}-{income_quarter.QuarterNumber}";

            if (!_quarter_files.Contains(current))
            {
                _quarter_files.Add(current);
                WriteSystem(current);
                _current_quarter = current;
            }
        }
        public static List<string> GetQuarterList()
        {
            return _quarter_files;
        }
        public static void SetCurrentQuarter(int id)
        {
            _current_quarter = _quarter_files[id - 1];
        }
        public static string CheckCurrentQuarter()
        {
            return _current_quarter;
        }

        public static void SetCurrentFilePath()
        {
            _current_file_record = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"{_current_quarter}-Energy.txt");
            _current_file_quarter = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"{_current_quarter}-Quarter.txt");
        }
        //Methot wich create file if it not exist
        public static void InitFile()
        {
            if (!File.Exists(_current_file_record))
            {
                using (FileStream fs = File.Create(_current_file_record));
            }

            if (!File.Exists(_current_file_quarter))
            {
                using (FileStream fs = File.Create(_current_file_quarter));
            }
        }

        public static void WriteRecord(EnergyRecord record)
        {
            if (File.Exists(_current_file_record))
            {
                using (StreamWriter file = new StreamWriter(_current_file_record, true))
                {
                    file.WriteLine(record.GetStingToWrite());
                }
            }
            UpdateQuarter();
        }
        public static List<EnergyRecord> ReadAllRecord()
        {
            List<EnergyRecord> result = new List<EnergyRecord>();

            if (File.Exists(_current_file_record))
            {
                string line = "";
                using (StreamReader file = new StreamReader(_current_file_record))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        result.Add(new EnergyRecord(line.Split(';')));
                    }
                }
            }
            return result;
        }

        public static EnergyRecord ReadRecordByID(int id)
        {
            string result = "";
            EnergyRecord record = null;
            if (File.Exists(_current_file_record))
            {
                string line = "";
                bool marker = true;
                using (StreamReader file = new StreamReader(_current_file_record))
                {
                    while (((line = file.ReadLine()) != null) && marker)
                    {
                        if ((line.Split(';'))[0] == id.ToString())
                        {
                            result = line;
                            marker = false;
                        }   
                    }
                }
            }
            try
            {
                if (result == "")
                {
                    throw new Exception("No such record found");
                }
                record = new EnergyRecord(result.Split(';'));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return record;
        }

        public static bool ExistID(int id)
        {
            bool marker = true;
            if (File.Exists(_current_file_record))
            {
                string line = ""; 
                using (StreamReader file = new StreamReader(_current_file_record))
                {
                    while (((line = file.ReadLine()) != null) && marker)
                    {
                        if ((line.Split(';'))[0] == id.ToString())
                        {
                            marker = false;
                        }
                    }
                }
            }
            return !marker;
        }

        public static EnergyRecord FindBiggestDebt()
        {
            EnergyRecord record = null;
            EnergyRecord temp;
            if (File.Exists(_current_file_record))
            {
                string line = "";
                double debt = 0;
                using (StreamReader file = new StreamReader(_current_file_record))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if ((temp = new EnergyRecord(line.Split(';'))).SumDept() >= debt)
                        {
                            record = temp;
                            debt = temp.SumDept();
                        }
                    }
                }
            }
            return record;
        }

        public static List<EnergyRecord> FindNoConsume()
        {
            List<EnergyRecord> record = new List<EnergyRecord>();
            EnergyRecord temp;
            if (File.Exists(_current_file_record))
            {
                string line = "";
                using (StreamReader file = new StreamReader(_current_file_record))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if ((temp = new EnergyRecord(line.Split(';'))).SumDept() == 0)
                        {
                            record.Add(temp);
                        }
                    }
                }
            }
            return record;
        }

        public static void ClearRecords()
        {
            if (File.Exists(_current_file_record))
            {
                using (StreamWriter file = new StreamWriter(_current_file_record))
                {
                    file.WriteLine(string.Empty);
                }
            }
            UpdateQuarter();
        }

        public static int CountRecords()
        {
            int line_count = 0;
            if (File.Exists(_current_file_record))
            {
                
                using (StreamReader file = new StreamReader(_current_file_record))
                {
                    while (file.ReadLine() != null)
                    {
                        line_count++;
                    }
                }
            }
            return line_count;
        }


        //For working with Quarter
        //________________________

        public static void WriteQuarter(int income)
        {
            int count_consumer = CountRecords();
            if (File.Exists(_current_file_quarter))
            {
                using (StreamWriter file = new StreamWriter(_current_file_quarter))
                {
                    file.WriteLine($"{count_consumer};{income};");
                }
            }
        }

        public static void UpdateQuarter()
        {
            int count_consumer = CountRecords();
            if (File.Exists(_current_file_quarter))
            {
                string line = "";
                string[] args = new string[2];
                using (StreamReader file = new StreamReader(_current_file_quarter))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        args = line.Split(";");
                    }
                }
                using (StreamWriter file = new StreamWriter(_current_file_quarter))
                {
                    file.WriteLine($"{count_consumer};{args[1]};");
                }

            }
        }

        public static EnergyQuarter ReadQuarter()
        {
            EnergyQuarter quarter_info = null;
            if (File.Exists(_current_file_quarter))
            {
                string line = "";
                using (StreamReader file = new StreamReader(_current_file_quarter))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        quarter_info = new EnergyQuarter(line.Split(";"));
                    }
                }
            }
            return quarter_info;
        }

        public static bool QuarterFileEmpty()
        {
            bool quarter_info = true;
            if (File.Exists(_current_file_quarter))
            {
                string line = "";
                using (StreamReader file = new StreamReader(_current_file_quarter))
                {
                    while (file.ReadLine() != null)
                    {
                        quarter_info = false;
                    }
                }
            }
            return quarter_info;
        }
    }
}
