using System.Collections;
using System.Text;


namespace exercise_3
{
    public class Unique
    {
        private string[] _income_str;

        public Unique(string income_str)
        {
            _income_str = income_str.Split(' ');
        }
        public IEnumerator GetEnumerator()
        {
            foreach (var item in _income_str)
            {
                if (Array.IndexOf(_income_str, item) == Array.LastIndexOf(_income_str, item))
                {
                    yield return item;
                }
            }
        }

        public override string? ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("\nIncome all words:");
            foreach (var item in _income_str)
            {
                stringBuilder.AppendLine(item);
            }
            return stringBuilder.ToString();
        }
    }
}
