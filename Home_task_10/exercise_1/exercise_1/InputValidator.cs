//Validates entered brand or card information
//It is used for both types of information input - reading from a file and from the console
using System.Text.RegularExpressions;

namespace exercise_1
{
    internal static class InputValidator
    {
        public static bool ValidateCardInput(string income)
        {
            bool result = true;

            try
            {
                CheckEmpty(income);

                string pattern_card = "^(# ).*( # )[card_number]*( = )\"[0-9]*\"$";
                bool matches = Regex.IsMatch(income, pattern_card);
                if (!matches)
                {
                    throw new FormatException($"\nEnter the Card information according to the template. The card was not registered: /...{income}.../");
                }

                CheckEmptySplit(income);
            }
            catch (FormatException ex)
            {
                result = false;
                View.PrintExceptionMessage(ex.Message);
            }

            return result;
        }

        public static bool ValidateBrandInput(string income)
        {
            bool result = true;

            try
            {
                CheckEmpty(income);

                string pattern_card = "^(#)[A-Za-z0-9]*[^#]*(#)[0-9|]*(#)[0-9|]*$";
                bool matches = Regex.IsMatch(income, pattern_card);
                if (!matches)
                {
                    throw new FormatException("\nEnter the Brand information according to the template");
                }

                CheckEmptySplit(income);
            }
            catch (FormatException ex)
            {
                result = false;
                View.PrintExceptionMessage(ex.Message);
            }

            return result;
        }

        private static void CheckEmptySplit(string income)
        {
            int count_scharp = income.Count(s => s == '#');
            string[] splited_income = income.Split('#', StringSplitOptions.RemoveEmptyEntries);
            if (Array.Exists(splited_income, element => element == "") || count_scharp != splited_income.Length)
            {
                throw new FormatException("\nDo not leave spaces between #");
            }
        }
        private static void CheckEmpty(string income)
        {
            if (income == "")
            {
                throw new FormatException("\nEmpty input");
            }
        }
    }
}
