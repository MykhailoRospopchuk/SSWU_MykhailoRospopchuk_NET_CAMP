namespace exercise_3
{
    internal static class Currency
    {
        private static double _currency = 1;

        public static void SetCurrency(double curr)
        {
            if (curr > 0)
            {
                _currency = curr;
            } 
        }

        public static double GetCurrency()
        {
            return _currency;
        }

    }
}
