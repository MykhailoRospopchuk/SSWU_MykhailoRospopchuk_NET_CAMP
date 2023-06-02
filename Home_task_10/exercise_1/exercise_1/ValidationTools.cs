
namespace exercise_1
{
    internal static class ValidationTools
    {
        public static bool LunaCheckCard(string card_number)
        {
            int count_digits = card_number.Length;

            int sum = 0;
            bool is_second = false;

            for (int i = count_digits - 1; i >= 0; i--)
            {
                int d = card_number[i] - '0';

                if (is_second) d *= 2;

                sum += (d > 9) ? (d - 9) : d;

                is_second = !is_second;
            }
            return (sum % 10 == 0);
        }

        public static bool CheckCardRule(string card_brand, string card_number)
        {
            bool mark = false;
            Bank current_bank = BankBrands.GetBankByBrand(card_brand);
            Rule current_rule = current_bank.BankRule;

            foreach (var item in current_rule.Length)
            {
                if (item == card_number.Length) mark = true;
            }

            foreach (var item in current_rule.Prefix)
            {
                if (card_number.StartsWith(item)) mark = true;
            }

            return mark;
        }

        public static bool CheckCardBrand(string card_brand)
        {
            return BankBrands.CheckBrand(card_brand);
        }
    }
}
