namespace exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            FileWorker.InitFile();

            string[] test = FileWorker.ReadFile();

            //Selects all possible candidates from the proposed text for validation
            List<string> list = new List<string>();
            list = EmailValidator.SeparateAllVariants(test);

            //We initialize lists for storing addresses that have passed and failed validation
            List<string> valid = new List<string>();
            List<string> non_valid = new List<string>();

            //Performs validation of selected candidates
            (valid, non_valid) = EmailValidator.SeparateValid(list);

            //Displaying the results to the console
            Console.WriteLine("Valid!\n\n");
            valid.ForEach(Console.WriteLine);

            Console.WriteLine("\n\n");

            Console.WriteLine("Not valid!\n\n");
            non_valid.ForEach(Console.WriteLine);

        }
    }
}