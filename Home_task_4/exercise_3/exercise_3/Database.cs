// This static class is responsible for working with text files.
// The fields store information about the path to the system file, the current quarter, the path to the working files of the current quarter
using System.Collections.Generic;

namespace exercise_3
{
    internal static class Database
    {
        private static List<string> _quarter_files = new List<string>();
        private static string _system_path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"system_path.txt");
        private static string _current_quarter = "";
        private static string _current_file_record = "";
        private static string _current_file_quarter = "";

        //When the constructor is called, it is checked whether a system file with a list of quarters exists.
        //If not, it is created.
        //If it exists, the list of quarters is read into the static field of the class
        static Database()
        {
            if (!File.Exists(_system_path))
            {
                using (FileStream fs = File.Create(_system_path));
            }
            ReadSystem();
        }

        //The method is responsible for reading the list of quarters from the system file
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

        //The method is responsible for writing the quarter to the system file
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

        //The method is responsible for entering a new quarter into the system file.
        //When you create a new quarter, it is automatically defined as the current quarter to work with
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

        //The method is used to set the current quarter from the list of previously created quarters by the number of the quarter in the list
        public static void SetCurrentQuarter(int id)
        {
            _current_quarter = _quarter_files[id - 1];
        }

        //The method creates a path to the working files and stores them in the corresponding fields of the class
        //In the future, these fields will be used to access specific files
        public static void SetCurrentFilePath()
        {
            _current_file_record = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"{_current_quarter}-Energy.txt");
            _current_file_quarter = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, $"{_current_quarter}-Quarter.txt");
        }

        //The method returns the value of the current quarter
        public static string CheckCurrentQuarter()
        {
            return _current_quarter;
        }

        //The method returns the list of all registred quarter
        public static List<string> GetQuarterList()
        {
            return _quarter_files;
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

        //The method makes an new record in the working text file of the records of the current quarter
        public static void WriteRecord(EnergyRecord record)
        {
            if (File.Exists(_current_file_record))
            {
                using (StreamWriter file = new StreamWriter(_current_file_record, true))
                {
                    file.WriteLine(record.GetStingToWrite());
                }
            }
            UpdateQuarter(); //Сall the method for updating the number of records in the information about the current quarter
        }

        //The method reads all records in the current quarter
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

        //The method reads one record from the current quarter by its number in the current quarter
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

        //The method checks whether there is a record for the specified number in the current quarter
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

        //The method finds a list of records that have the highest debt value in the current quarter.
        //If the debt is the same in several records, all records with the same debt will be returned
        public static List<EnergyRecord> FindBiggestDebt()
        {
            List<EnergyRecord> record = new List<EnergyRecord>();
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
                            debt = temp.SumDept();
                        }
                    }
                    
                }
                using (StreamReader file = new StreamReader(_current_file_record))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        if ((temp = new EnergyRecord(line.Split(';'))).SumDept() == debt)
                        {
                            record.Add(temp);
                        }
                    }
                } 
            }
            return record;
        }

        //The method returns a list of entries in the current quarter that have zero consumption
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

        //Deletes all records from the current quarter
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

        //Returns the number of records in the current quarter
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

        //Writes quarter data to the current quarter file
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

        //Updates data about the current quarter.
        //Used to update the number of records in a quarter
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

        //Reads data about the current quarter
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

        //Checks whether information for the current quarter is written to the file
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
