using System.Diagnostics.Metrics;

namespace exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //If the file has not been created, it will be automatically created to enter the source text for verification
            FileWorker.InitFile();
            //Read from the file
            string[] test = FileWorker.ReadFile();

            //Selects all possible candidates from the proposed text for validation
            List<string> list = new();
            list = EmailValidator.SeparateAllVariants(test);

            //Validation of proposed emails using a custom method
            //--------------------------------------------------
            Console.WriteLine("\n\nCustom Validator:");
            Console.WriteLine("____________________");

            List<string> valid_custom = new List<string>();
            List<string> non_valid_custom = new List<string>();
            (valid_custom, non_valid_custom) = EmailValidator.SeparateValidCustom(list);

            //Displaying the results to the console
            Console.WriteLine("List of Valid email using custom method!:\n");
            valid_custom.ForEach(Console.WriteLine);

            Console.WriteLine("\n\n");

            Console.WriteLine("List of Non valid email using custom method!:\n");
            non_valid_custom.ForEach(Console.WriteLine);


            //Validation of proposed emails using a using Regex from MSDN
            //It is used only for visual purposes to compare results
            //--------------------------------------------------
            Console.WriteLine("\nRegex Validator recomendet MSDN:");
            Console.WriteLine("____________________");

            //Initialize lists for storing addresses that have passed and failed validation
            List<string> valid = new List<string>();
            List<string> non_valid = new List<string>();

            //Performs validation of selected candidates
            (valid, non_valid) = EmailValidator.SeparateValidRegex(list);

            //Displaying the results to the console
            Console.WriteLine("Valid MSDN!:\n");
            valid.ForEach(Console.WriteLine);

            Console.WriteLine("\n\n");

            Console.WriteLine("Non valid MSDN!:\n");
            non_valid.ForEach(Console.WriteLine);
        }
    }
}
