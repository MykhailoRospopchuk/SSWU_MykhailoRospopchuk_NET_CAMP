//The class performs the function of current storage of data about the state of traffic lights
namespace exercise_b.DataWorker
{
    internal static class DataHandler
    {
        private static string _handled_string;

        public static void SetString(string income)
        {
            _handled_string = income;
        }
        public static string GetString()
        {
            return _handled_string;
        }
    }
}
