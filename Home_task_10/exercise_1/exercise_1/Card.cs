namespace exercise_1
{
    public class Card : ICard
    {
        private readonly string _credit_card_brand;
        private readonly string _credit_card_number;
        private bool _is_valid = false;
        public Card(string credit_card_brand, string credit_card_number)
        {
            _credit_card_brand = credit_card_brand;
            _credit_card_number = credit_card_number;
        }

        public string CreditCardBrand { get {  return _credit_card_brand; } }
        public string CreditCardNumber { get {  return _credit_card_number; } }
        public bool IsValid { get { return _is_valid; } set { _is_valid = value; } }


        public override string? ToString()
        {
            return $"#{_credit_card_brand}# card_number = {_credit_card_number}";
        }
    }
}