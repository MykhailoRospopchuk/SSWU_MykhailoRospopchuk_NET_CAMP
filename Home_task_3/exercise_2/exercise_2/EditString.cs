using System.Text;

namespace exercise_2
{
    internal static class EditString
    {
        //The first exercise
        public static int? FindString(string str_source, string str_found)
        {// Можна з тернарним в одну стрічку
            //Looking for the first occurrence of the searched string.
            int first_index = str_source.IndexOf(str_found);
            if (first_index == -1)
            {
                return null;
            }
            //Looking to see if there is a second occurrence of the searched string starting from the last occurrence
            int second_index = str_source.IndexOf(str_found, first_index + 1);
            if (second_index == -1)
            {
                return null;
            }
            return second_index;
        }

        //The second exercise
        public static int FindUpperCase(string str_source)
        { // Тут перемудрили. Все значно простіше. Поясню...
            int index_out = 0;

            int count = 0;
            string[] string_array = str_source.Split(' ');
            int lenght = string_array.Length;
            
            while (index_out < lenght)
            {
                int index_in = 0;
                string current = string_array[index_out];
                //If the current line is empty, then skip it
                if (current.Length == 0)
                {
                    index_out++;
                    continue;
                }
                //If the first character is an uppercase letter, then the counter increases and move to the next line
                if (current[0] > 64 && current[0] < 91)
                {
                    count++;
                    index_out++;
                    //Уникайте...
                    continue;
                }
                else
                {
                    while (current[index_in] != '\0')
                    {
                        //If the character is a lowercase letter, exit the loop
                        if ((current[index_in] > 96 && current[index_in] < 123) || (current[index_in] > 47 && current[index_in] < 58))
                        {
                            break;
                        }
                        //If the character is a number, counter increases and exit the loop
                        if (current[index_in] > 64 && current[index_in] < 91)
                        {
                            count++;
                            break;
                        }
                        index_in++;
                    }
                }
                index_out++;
            }  
            return count;
        }

        //The third exercise
        public static string ReplaceDouble(string str_source, string str_replace)
        {// знову ж алгоритмічно ускладнено...
            string[] string_array = str_source.Split(' ');
            StringBuilder result_str = new StringBuilder();
            int iterator = 0;
            int lenght = string_array.Length;

            while (iterator < lenght)
            {
                int iterator_in = 1;
                string current = string_array[iterator];
                int current_lenght = current.Length;
                //If the current line is shorter than two characters, do not check it and move on to the next line
                if (current_lenght < 2)
                {
                    //If the current line is empty, put space in it
                    if (current == "")
                    {
                        string_array[iterator] = " ";
                    }
                    result_str.Append(string_array[iterator]);
                    iterator++;
                }
                else
                {
                    while (iterator_in < current_lenght)
                    {
                        //Сheck whether the current character in the line is a letter
                        if ((current[iterator_in] > 96 && current[iterator_in] < 123) || (current[iterator_in] > 64 && current[iterator_in] < 91))
                        {
                            //If two adjacent characters are the same, then we replace the current line with the one specified by the user
                            if ((current[iterator_in] == current[iterator_in - 1]))
                            {
                                string_array[iterator] = str_replace;
                                break;
                            }
                        }
                        iterator_in++;
                    }
                }
                result_str.Append(string_array[iterator]+" ");
                iterator++;
            }
            return result_str.ToString();
        }
    }
}
