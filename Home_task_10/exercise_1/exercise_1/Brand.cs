//Simulates the essence of the Card Brand.
//Stores data about the name of the brand and the rules of the given brand

//According to the rules of the brand, in the future,
//the submitted cards for verification will be checked for compliance with the brand
namespace exercise_1
{
    internal class Brand : IEquatable<Brand>
    {
        private readonly string _bank_name;
        private readonly Rule _bank_rule;

        public Brand(string bank_name, Rule bank_rule)
        {
            _bank_name = bank_name;
            _bank_rule = bank_rule;
        }

        public string BrandName { get { return _bank_name; } }
        public Rule BrandRule { get { return _bank_rule; } }

        public bool Equals(Brand income)
        {
            if (income == null)
                return false;

            if (_bank_name == income.BrandName && _bank_rule == income.BrandRule)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return $"#{_bank_name}#{_bank_rule}";
        }
    }
}
