
using System.Text;

//It is used to output information to the console
namespace exercise_1
{
    internal static class View
    {
        public static void PrintAllCard(List<ICard> cards)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n");
            foreach (var card in cards)
            {
                sb.Append(CardToString(card));
                sb.Append("\n");
            }
            Console.WriteLine(sb.ToString());
        }
        public static void PrintCard(ICard card)
        {
            Console.WriteLine(CardToString(card));
        }

        private static string CardToString(ICard card)
        {
            if (card == null)
            {
                return "Card not created. Input error";
            }
            return $"Card Brand: {card.CreditCardBrand,-20} Card Number: {card.CreditCardNumber,-20} Valid: {card.IsValid}";
        }

        public static void PrintAllBank(List<Brand> banks)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var bank in banks)
            {
                sb.Append(BankToString(bank));
                sb.Append("\n");
            }
            Console.WriteLine(sb.ToString());
        }

        private static string BankToString(Brand bank)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Card Brand: {bank.BrandName, -20}");
            sb.Append("\n\tCredit card number length: ");
            Rule rule = bank.BrandRule;
            rule.Length.ForEach(x => sb.Append($" {x,2};"));
            sb.Append("\n\tBrand number prefix:      ");
            rule.Prefix.ForEach(x => sb.Append($" {x,4};"));

            return sb.ToString();
        }

        public static void PrintErrorPoint(string message, ICard card)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Error in module {message} - Card Brand: {card.CreditCardBrand,-20} Card Number: {card.CreditCardNumber,-20}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintExceptionMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
