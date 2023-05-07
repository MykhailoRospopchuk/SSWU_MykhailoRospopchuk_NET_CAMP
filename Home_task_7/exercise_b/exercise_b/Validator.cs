//The class validates the user-entered duration of the simulation
namespace exercise_b
{
    internal static class Validator
    {
        public static bool ValidateRecord(int income)
        {
            bool result = true;
            try
            {
                if (income < 0)
                {
                    throw new Exception("The value must be greater or equal than zero");
                }
            }
            catch (Exception ex)
            {
                result = false;
                Console.WriteLine(ex);
            }
            return result;
        }
    }
}
