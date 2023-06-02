
namespace exercise_1
{
    internal class Bank
    {
        private readonly string _bank_name;
        private readonly Rule _bank_rule;

        public Bank(string bank_name, Rule bank_rule)
        {
            _bank_name = bank_name;
            _bank_rule = bank_rule;
        }

        public string BankName { get { return _bank_name; } }
        public Rule BankRule { get { return _bank_rule; } }

        public override string ToString()
        {
            return $"#{_bank_name}#{_bank_rule}";
        }
    }
}
