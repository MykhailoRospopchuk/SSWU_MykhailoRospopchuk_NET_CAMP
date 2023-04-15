//A statiс class to check the data based on which the user wants to create a new record in the current quarter
using System.Globalization;

namespace exercise_3
{
    internal static class Validator
    {
        public static bool ValidateRecord(string income)
        {
            bool result = true;
            string[] args = income.Split(';');
            try
            {
                int id = Convert.ToInt32(args[0]);
                if ((Database.ExistID(id)))
                {
                    throw new Exception("Id alredy exist");
                }
                if (args[1].Length == 0 || args[2].Length == 0)
                {
                    throw new Exception("Address and Surname are necessarily");
                }
                if (args[3].Length < 0 || args[4].Length < 0 || args[5].Length < 0)
                {
                    throw new Exception("Electricity measurements cannot be negative");
                }
                var current_quarter = Database.ReadQuarter().Month;
                if (args[6] != "" && !(DateTime.Parse(args[6]).ToString("MMMM", CultureInfo.GetCultureInfo("en-US")) == current_quarter[0]))
                {
                    throw new Exception($"The first month {DateTime.Parse(args[6]).ToString("MMMM", CultureInfo.GetCultureInfo("en-US"))}is not the first month of the current quarter {current_quarter[0]}");
                }
                if (args[7] != "" && !(DateTime.Parse(args[7]).ToString("MMMM", CultureInfo.GetCultureInfo("en-US")) == current_quarter[1]))
                {
                    throw new Exception($"The second month {DateTime.Parse(args[7]).ToString("MMMM", CultureInfo.GetCultureInfo("en-US"))}is not the second month of the current quarter {current_quarter[1]}");
                }
                if (args[8] != "" && !(DateTime.Parse(args[8]).ToString("MMMM", CultureInfo.GetCultureInfo("en-US")) == current_quarter[2]))
                {
                    throw new Exception($"The third month {DateTime.Parse(args[8]).ToString("MMMM", CultureInfo.GetCultureInfo("en-US"))}is not the third month of the current quarter {current_quarter[2]}");
                }
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex);
            }
            return result;
        }
    }
}
