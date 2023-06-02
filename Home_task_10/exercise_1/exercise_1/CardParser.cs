using System.Text.RegularExpressions;

namespace exercise_1
{
    internal static class CardParser
    {
        public static Card Parse(string income_card)
        {
            if (!InputValidator.ValidateCardInput(income_card))
            {
                throw new FormatException("Input Card not pass validation\n");
            }
            string[] splited_bank = income_card.Split('#', StringSplitOptions.RemoveEmptyEntries);

            string bank_name = splited_bank[0].Trim();
            string bank_number = SelectCardNumber(splited_bank[1]);

            return new Card(bank_name, bank_number);
        }

        private static string SelectCardNumber(string income_str)
        {
            var firstPattern = @"(?<="")[0-9]+(?="")";

            Regex regex = new Regex(firstPattern);
            var matches = regex.Match(income_str);

            return matches.Value;
        }
    }
}
