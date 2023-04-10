//This static class is created for text manipulation
namespace exercise_1
{
    internal static class TextParser
    {
        public static void FindText(string[] text)
        {
            var open = FindOpenBracket(text);
            open.ForEach(x => Console.WriteLine($"Open bracket: {x.Row}, {x.Index}"));

            var close = FindClosenBracket(text);
            close.ForEach(x => Console.WriteLine($"Close bracket: {x.Row}, {x.Index}"));

            Console.WriteLine("Sentence");
            var res = FindSentencet(text, open, close);
            if (res.Count == 0)
            {
                Console.WriteLine("\nThere is not text inside bracket\n");
            }
            res.ForEach(text => Console.WriteLine($"Begin: {text[0].Row}, {text[0].Index}; End: {text[1].Row}, {text[1].Index}"));

            PrintSentence(res, text);
        }

        //This method searches for open brackets in the text
        private static List<Point> FindOpenBracket(string[] text)
        {
            List<Point> open_bracket = new List<Point>();
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < (text[i]).Length; j++)
                {
                    if ((text[i])[j] == '(')
                    {
                        open_bracket.Add(new Point(i, j));
                    }
                }
            }
            return open_bracket;
        }

        //This method searches for close brackets in the text
        private static List<Point> FindClosenBracket(string[] text)
        {
            List<Point> close_bracket = new List<Point>();
            for (int i = 0; i < text.Length; i++)
            {
                for (int j = 0; j < (text[i]).Length; j++)
                {
                    if ((text[i])[j] == ')')
                    {
                        close_bracket.Add(new Point(i, j));
                    }
                }
            }
            return close_bracket;
        }

        //This method searches for sentences that contain text in dashes.
        //The arguments of the method are a list of points in which there are open and closed brackets and the text itself
        private static List<Point[]> FindSentencet(string[] text, List<Point> open_bracket, List<Point> close_bracket)
        {
            List<Point[]> sentencet = new List<Point[]>();
            int length = open_bracket.Count;
            Point temp_one = new Point(0, 0);
            Point temp_second = new Point(0, 0);
            bool marker = false;
            bool inside = false;

            //We perform pairwise traversal of the points with brackets in the text
            for (int k = 0; k < length; k++)
            {
                //The search for the beginning of the sentence relative to the open bracket is performed
                int i = open_bracket[k].Row;
                int j = open_bracket[k].Index;
                while (i >= 0)
                {
                    if (i != open_bracket[k].Row)
                    {
                        j = (text[i]).Length - 1;
                    }
                    while (j>=0)
                    {
                        if ((text[i])[j] == ')') inside = true;
                        if ((text[i])[j] == '(') inside = false;
                        if (((text[i])[j] == '.' || (text[i])[j] == '!' || (text[i])[j] == '?') && !inside)
                        {
                            if (j == (text[i]).Length - 1) temp_one = new Point(i + 1, 0);
                            else temp_one = new Point(i, j);
                            marker = true;
                            break;
                        }
                        j--;
                    }
                    if (marker)
                    {
                        marker = false;
                        break;
                    }
                    i--;
                }

                //The search for the beginning of the sentence relative to the open bracket is performed
                i = close_bracket[k].Row;
                j = close_bracket[k].Index;
                while (i < text.Length)
                {
                    while (j < (text[i]).Length)
                    {
                        if ((text[i])[j] == '(') inside = true;
                        if ((text[i])[j] == ')') inside = false;
                        if (((text[i])[j] == '.' || (text[i])[j] == '!' || (text[i])[j] == '?') && !inside)
                        {
                            temp_second = new Point(i, j);
                            marker = true;
                            break;
                        }
                        j++;
                    }
                    if (marker)
                    {
                        marker = false;
                        break;
                    }
                    j = 0;
                    i++;
                }
                sentencet.Add(new Point[] {temp_one, temp_second});

            }
            return sentencet;
        }

        //This method outputs to the console sentences that have text in dashes.
        //The arguments in the method are the text itself, the beginning and end of the sentence
        private static void PrintSentence(List<Point[]> sentence, string[] text)
        {
            Console.WriteLine(" \nSentence with brackets: ");
            sentence.ForEach(point =>
            {
                bool marker = true;
                int i = point[0].Row;
                int j = point[0].Index;
                while (marker)
                {
                    while (j < text[i].Length)
                    {
                        Console.Write((text[i])[j]);
                        if (i == point[1].Row && j == point[1].Index)
                        {
                            marker = false;
                            break;
                        }
                        j++;
                    }
                    Console.Write(' ');
                    j = 0;
                    i++;
                }
                Console.WriteLine("\n");
            });
        }
    }
}
