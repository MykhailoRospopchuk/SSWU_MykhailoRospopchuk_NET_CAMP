//The static class implements three verification mechanisms:
//  - LunaCheckCard - Verification of the Luna algorithm;
//  - CheckCardRule - Check for compliance with the conditions for the current type of card brand;
//  - CheckCardBrand - Checking whether the specified card brand exists in the list of registered ones.

// It is used in every link of the chain of responsibility
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
            bool mark_length = false;
            bool mark_prefix = false;
            Brand current_bank = CardBrands.GetBrandByName(card_brand);
            Rule current_rule = current_bank.BrandRule;

            foreach (var item in current_rule.Length)
            {
                if (item == card_number.Length) mark_length = true;
            }

            foreach (var item in current_rule.Prefix)
            {
                if (card_number.StartsWith(item)) mark_prefix = true;
            }

            return mark_length && mark_prefix;
        }

        public static bool CheckCardBrand(string card_brand)
        {
            return CardBrands.CheckBrand(card_brand);
        }
    }
}
