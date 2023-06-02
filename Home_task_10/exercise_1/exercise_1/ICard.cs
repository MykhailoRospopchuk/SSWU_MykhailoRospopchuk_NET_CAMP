namespace exercise_1
{
    public interface ICard
    {
        public string CreditCardBrand { get; }
        public string CreditCardNumber { get; }
        public bool IsValid { get; set; }
    }
}