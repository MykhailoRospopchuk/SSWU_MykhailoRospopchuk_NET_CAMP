//Simulates the essence of the rule that must be checked for card validation
//#Visa New#17|19#4|71|25 where in Rule object save:
//  - 17|19 - The number of digits in the number is 17 or 19
//  - 4|71|25 - Possible Card number prefixes 4 or 71 or 25
//Name of Brand saving in Brand class.
using System.Text;

namespace exercise_1
{
    internal class Rule : IEquatable<Rule>
    {
        //List of possible card number lengths
        //and list of possible number prefixes
        private readonly List<int> _card_number_length;
        private readonly List<string> _identification_number_prefix;

        public Rule(List<int> card_number_length, List<string> identification_number_prefix)
        {
            _card_number_length = card_number_length;
            _identification_number_prefix = identification_number_prefix;
        }
        public List<int> Length
        {
            get { return _card_number_length; }
        }

        public List<string> Prefix
        {
            get { return _identification_number_prefix;}
        }

        public override string ToString()
        {
            int count_number_identify = _card_number_length.Count;
            int count_prefix_identify = _identification_number_prefix.Count;

            StringBuilder sb = new StringBuilder();
            sb.Append($"{_card_number_length[0]}");
            for (int i = 1; i < count_number_identify; i++)
            {
                sb.Append($"|{_card_number_length[i]}");
            }

            sb.Append("#");

            sb.Append($"{_identification_number_prefix[0]}");
            for (int i = 1; i < count_prefix_identify; i++)
            {
                sb.Append($"|{_identification_number_prefix[i]}");
            }
            return sb.ToString();
        }


        public bool Equals(Rule income)
        {
            if (income == null)
                return false;

            bool is_equal_length = Enumerable.SequenceEqual(_card_number_length.OrderBy(e => e), income.Length.OrderBy(e => e));
            bool is_equal_prefix = Enumerable.SequenceEqual(_identification_number_prefix.OrderBy(p => p), income.Prefix.OrderBy(p => p));

            if (is_equal_length && is_equal_prefix)
                return true;
            else
                return false;
        }

        public static bool operator ==(Rule rule_1, Rule rule_2)
        {
            if (((object)rule_1) == null || ((object)rule_2) == null)
                return Equals(rule_1, rule_2);

            return rule_1.Equals(rule_2);
        }

        public static bool operator !=(Rule rule_1, Rule rule_2)
        {
            if (((object)rule_1) == null || ((object)rule_2) == null)
                return !Equals(rule_1, rule_2);

            return !(rule_1.Equals(rule_2));
        }
    }
}
