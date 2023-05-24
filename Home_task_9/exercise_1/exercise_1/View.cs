using System.Diagnostics;

namespace exercise_1
{
    internal static class View
    {
        private static Stopwatch _st = new Stopwatch();

        static View()
        {
            _st.Start();
        }


        public static void PrintWithTime(string text)
        {
            TimeSpan curr_st = _st.Elapsed;
            Console.Write("{0:00}:{1:00}.{2:00} - ", curr_st.Minutes, curr_st.Seconds, curr_st.Milliseconds / 10);
            Console.WriteLine(text);
        }

        public static void PrintWithOutTime(string text)
        {
            Console.WriteLine(text);
        }
    }
}
