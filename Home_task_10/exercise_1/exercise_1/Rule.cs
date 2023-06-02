using System.Text;

namespace exercise_1
{
    internal class Rule
    {
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
    }
}
