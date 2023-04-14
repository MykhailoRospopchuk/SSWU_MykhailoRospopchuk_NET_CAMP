
namespace exercise_3
{
    internal static class Menu
    {
        private static string[] _options = {
            "1 - Get all records by quarter",
            "2 - Get a specific entry in the quarter",
            "3 - Get the record with the most debt",
            "4 - Get a record without consumption",
            "5 - Specify a new quarter",
            "6 - Choose a quarter from the existing ones",
            "7 - Set currency rate",
            "8 - Set new record",
            "9 - Exit"
        };
        private static void PrintMenu()
        {
            Console.WriteLine("--------------MENU--------------");
            foreach (var item in _options)
            {
                Console.WriteLine(item);
            }
        }

        private static void SignInQuarter()
        {
            if (Database.CheckCurrentQuarter() == "")
            {
                Console.WriteLine("\nPay attention!\nYou have not specified the current work QUARTER");
                Console.WriteLine("Create a quarter record using the menu, or select one of the existing ones.");
            }
            else 
            {
                Console.WriteLine("Quarter is selected: " + Database.CheckCurrentQuarter());
            };
        }

        public static void MainMenu()
        {
            int user_option = 0;
            while (true)
            {
                PrintMenu();
                SignInQuarter();
                try
                {
                    user_option = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Please enter an integer value between 1 and " + _options.Length);
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error happened. Please try again");
                    Console.WriteLine(ex);
                    continue;
                }

                switch (user_option)
                {
                    case 1:
                        GetAllRecordsByQuarter();
                        break;
                    case 2:
                        GetOneRecordsByQuarter();
                        break;
                    case 3:
                        GetRecordWithMostDebt();
                        break;
                    case 4:
                        GetRecordWithoutConsumption();
                        break;
                    case 5:
                        SpecifyNewQuarter();
                        break;
                    case 6:
                        ChooseQuarter();
                        break;
                    case 7:
                        SetCurrencyRate();
                        break;
                    case 8:
                        SetNewRecord();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter an integer value between 1 and " + _options.Length + "or 9 for exit");
                        break;
                }
            }
        }
        
        // 1
        public static void GetAllRecordsByQuarter()
        {
            try
            {
                var result = Database.ReadAllRecord();
                var current_quarter = Database.ReadQuarter();
                View.PrintHeadRecord(current_quarter);
                result.ForEach(record => View.PrintFormatedRecord(record));
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error happened. Please try again");
                Console.WriteLine(ex);
            }
        }

        // 2
        public static void GetOneRecordsByQuarter()
        {
            int id = 0;
            try
            {
                Console.WriteLine("Enter the apartment number");
                id = Convert.ToInt32(Console.ReadLine());
                var record = Database.ReadRecordByID(id);
                var current_quarter = Database.ReadQuarter();
                if (record is not EnergyRecord)
                {
                    throw new Exception("No such record found");
                }
                View.PrintHeadRecord(current_quarter);
                View.PrintFormatedRecord(record);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error happened. Please try again");
                Console.WriteLine(ex);
            }
        }

        // 3
        public static void GetRecordWithMostDebt()
        {
            try
            {
                var record = Database.FindBiggestDebt();
                var current_quarter = Database.ReadQuarter();
                View.PrintHeadRecord(current_quarter);
                View.PrintFormatedRecord(record);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error happened. Please try again");
                Console.WriteLine(ex);
            }
        }

        // 4
        public static void GetRecordWithoutConsumption()
        {
            try
            {
                var record = Database.FindNoConsume();
                var current_quarter = Database.ReadQuarter();
                View.PrintHeadRecord(current_quarter);
                record.ForEach(r => View.PrintFormatedRecord(r));
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error happened. Please try again");
                Console.WriteLine(ex);
            }
        }

        // 5
        private static void SpecifyNewQuarter()
        {
            int quarter = 1;
            int year_int = 2023;
            DateTime year = DateTime.Now;
            try
            {
                Console.WriteLine("Set the number of quarter (from 1 to 4)");
                quarter = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Set the year of quarter (can't be bigest than {DateTime.Now.Year})");
                year_int = Convert.ToInt32(Console.ReadLine());
                year = new DateTime(year_int, DateTime.Now.Month, DateTime.Now.Day);
                if (quarter > 4 || quarter < 1)
                {
                    throw new System.FormatException();
                }
                
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please enter an integer value between 1 and 4");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error happened. Please try again");
                Console.WriteLine(ex);
            }

            EnergyQuarter quarter_new = new EnergyQuarter(quarter);
            Database.SetQuarterFileName(quarter_new, year);
            Database.SetCurrentFilePath();
            Database.InitFile();
            Database.WriteQuarter(quarter_new.QuarterNumber);
        }

        // 6
        private static void ChooseQuarter()
        {
            var quarters = Database.GetQuarterList();
            if (quarters.Count == 0)
            {
                Console.WriteLine("No quarter is registered in the database.\nCreate new one. Use option 5 from MENU");
            }
            else
            {
                Console.WriteLine("Chose Quarter from list");
                for (int i = 0; i < quarters.Count; i++)
                {
                    Console.WriteLine($"{i+1} - {quarters[i]}");
                }
                int user_quarter = 0;
                try
                {
                    user_quarter = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("Please enter an valid integer non zero");
                }
                Database.SetCurrentQuarter(user_quarter);
                Database.SetCurrentFilePath();
                Database.InitFile();
                if (Database.QuarterFileEmpty())
                {
                    Database.WriteQuarter(user_quarter);
                }
            }
        }

        // 7
        private static void SetCurrencyRate()
        {
            double quarr = 1;
            try
            {
                Console.WriteLine("Set the Currency Rate");
                quarr = Convert.ToDouble(Console.ReadLine());
                if (quarr < 0)
                {
                    throw new System.FormatException();
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please enter an value bigger than 0");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error happened. Please try again");
                Console.WriteLine(ex);
            }

            Currency.SetCurrency(quarr);
        }

        // 8
        private static void SetNewRecord()
        {
            try
            {
                Console.WriteLine("Enter the record data in the format. If there is no data, leave it blank, for example \"...;;...\"");
                Console.WriteLine($"Flat;Address;Surname;Consume;Consume;Consume;dd.mm.yyyy;dd.mm.yyyy;dd.mm.yyyy;");
                string args = Console.ReadLine();
                if (!Validator.ValidateRecord(args))
                {
                    throw new Exception("Some arguments are entered incorrectly");
                }
                EnergyRecord record = new EnergyRecord(args.Split(';'));
                Database.WriteRecord(record);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }
    }
}
