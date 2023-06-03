//Performs brand card parsing and returns an instance Brand
//Credit card information in the form is provided at the entrance
// #American Express#15#34|37 == #CARD BRAND#CREDIT CARD NUMBER LENGTH#IDENTIFICATION NUMBER PREFIX

//Used to parse brand card information from both a text file and user input into the console
namespace exercise_1
{
    internal static class BrandParser
    {
        public static Brand Parse(string income_bank)
        {
            //Call for validation of entered data
            if (!InputValidator.ValidateBrandInput(income_bank))
            {
                throw new FormatException("Input Bank not pass validation\n");
            }

            string[] splited_bank = income_bank.Split('#', StringSplitOptions.RemoveEmptyEntries);

            string bank_name = splited_bank[0];
            List<string> bank_number_length_str = (splited_bank[1]).Split('|').ToList();
            List<int> bank_number_length = bank_number_length_str.Select(int.Parse).ToList();
            string bank_prefix = splited_bank[2];

            return new Brand(bank_name, new Rule(bank_number_length, bank_prefix.Split('|').ToList()));
        }

        
    }
}
