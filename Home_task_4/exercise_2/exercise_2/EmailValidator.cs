
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

        //Performs custom validation a list of selected candidates
        public static (List<string>, List<string>) SeparateValidCustom(List<string> emails)
        {
            List<string> valid = new List<string>();
            List<string> non_valid = new List<string>();

            emails.ForEach(email =>
            {
                if (ValidatorEmail(email)) valid.Add(email);
                else non_valid.Add(email);
            });

            return (valid, non_valid);
        }

        //Directly the custom validation method
        private static bool ValidatorEmail(string email)
        {
            int index_et = email.LastIndexOf('@');
            string domain = email.Substring(index_et + 1);
            string local = email.Substring(0, index_et);

            string valid_chars_local = "!#$%&'*+-/=?^_`{|}~.()";
            string valid_chars_domain = "-.()";

            if (local.Length > 64) return false;

            bool local_in_double_quotes = local.EndsWith("\"") && local.StartsWith("\"");

            if (local.Length == 0 || domain.Length == 0) return false;

            if (local_in_double_quotes && local.Length == 1) return false;

            if (!local_in_double_quotes)
            {
                if (!CommentIsCorrect(local)) return false;

                foreach (char current_char in local)
                {
                    if (!Char.IsLetterOrDigit(current_char) && !valid_chars_local.Contains(current_char)) return false;
                }

                if (local.IndexOf('.') != -1 && local[local.IndexOf('.') + 1] == '.') return false;

                if (local.EndsWith('.') || local.StartsWith('.')) return false;
            }

            if (!CommentIsCorrect(domain)) return false;

            if (domain.StartsWith('-') || domain.EndsWith('-')) return false;

            if (domain.StartsWith('.') || domain.EndsWith('.')) return false;

            if (domain.IndexOf('.') != -1 && domain[domain.IndexOf('.') + 1] == '.') return false;

            foreach (char current_char in domain)
            {
                if (!Char.IsLetterOrDigit(current_char) && !valid_chars_domain.Contains(current_char)) return false;
            }

            return true;
        }
        //Checking for the correct use of comments
        private static bool CommentIsCorrect(string part_email)
        {
            int first_bracket = part_email.IndexOf('(');
            int second_bracket = part_email.IndexOf(')');

            if (first_bracket == -1 && second_bracket == -1) return true;
            else if ((first_bracket != -1 && second_bracket != -1) && second_bracket > first_bracket) return true;
            else return false;
        }


        //This method was added ONLY to visually COMPARE the results with the custom method!!!
        //Performs validation of selected candidates using Regex
        public static (List<string>, List<string>) SeparateValidRegex(List<string> emails)
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
