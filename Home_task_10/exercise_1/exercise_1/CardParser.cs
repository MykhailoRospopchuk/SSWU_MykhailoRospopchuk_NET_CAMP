//Performs credit card parsing and returns an instance Card
//Credit card information in the form is provided at the entrance
// # American Express # card_number = "378282246310005" == # CARD BRAND # card_number = "CARD NUMBER"

//Used to parse credit card information from both a text file and user input into the console
using System.Text.RegularExpressions;

namespace exercise_1
{
    internal static class CardParser
    {
        public static Card Parse(string income_card)
        {
            //Call for validation of entered data
            if (!InputValidator.ValidateCardInput(income_card))
            {
                return null;
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
