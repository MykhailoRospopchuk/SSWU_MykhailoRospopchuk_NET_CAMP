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
                    throw new FormatException("\nEnter the Card information according to the template");
                }

                CheckEmptySplit(income);
            }
            catch (FormatException ex)
            {
                result = false;
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public static bool ValidateBankInput(string income)
        {
            bool result = true;

            try
            {
                CheckEmpty(income);

                string pattern_card = "^(#)[A-Za-z0-9]*[^#]*(#)[0-9|]*(#)[0-9|]*$";
                bool matches = Regex.IsMatch(income, pattern_card);
                if (!matches)
                {
                    throw new FormatException("\nEnter the Bank information according to the template");
                }

                CheckEmptySplit(income);
            }
            catch (FormatException ex)
            {
                result = false;
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        private static void CheckEmptySplit(string income)
        {
            string[] splited_income = income.Split('#', StringSplitOptions.RemoveEmptyEntries);
            if (Array.Exists(splited_income, element => element == ""))
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
