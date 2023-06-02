
namespace exercise_1
{
    internal static class BankParser
    {
        public static Bank Parse(string income_bank)
        {
            if (!InputValidator.ValidateBankInput(income_bank))
            {
                throw new FormatException("Input Bank not pass validation\n");
            }

            string[] splited_bank = income_bank.Split('#', StringSplitOptions.RemoveEmptyEntries);

            string bank_name = splited_bank[0];
            List<string> bank_number_length_str = (splited_bank[1]).Split('|').ToList();
            List<int> bank_number_length = bank_number_length_str.Select(int.Parse).ToList();
            string bank_prefix = splited_bank[2];

            return new Bank(bank_name, new Rule(bank_number_length, bank_prefix.Split('|').ToList()));
        }

        
    }
}
