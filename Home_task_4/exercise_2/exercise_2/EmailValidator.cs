//This class directly validates the proposed email addresses
using System.Text.RegularExpressions;

namespace exercise_2
{
    internal static class EmailValidator
    {
        //Selects all possible candidates from the proposed text for validation
        public static List<string> SeparateAllVariants(string[] text)
        {
            List<string> result = new List<string>();

            string pattern = @"\S*[@]\S*";
            Regex rx = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            foreach (string variant in text)
            {
                MatchCollection matches = rx.Matches(variant);

                for (int i = 0; i < matches.Count; i++)
                {
                    result.Add(matches[i].Value);
                }
            }
            return result;
        }

        //Performs validation of selected candidates
        public static (List<string>, List<string>) SeparateValid(List<string> emails)
        {
            List<string> valid = new List<string>();
            List<string> non_valid = new List<string>();

            //Regular expression is officially suggested by MSDN and IBM
            //https://www.ibm.com/support/pages/email-address-format-validity
            //https://learn.microsoft.com/en-us/previous-versions/visualstudio/visual-studio-2008/01escwtf(v=vs.90)?redirectedfrom=MSDN

            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";

            foreach (var item in emails)
            {
                if (Regex.IsMatch(item, pattern, RegexOptions.IgnoreCase)) valid.Add(item);
                else non_valid.Add(item);
            }
            return (valid, non_valid);
        }
    }
}
