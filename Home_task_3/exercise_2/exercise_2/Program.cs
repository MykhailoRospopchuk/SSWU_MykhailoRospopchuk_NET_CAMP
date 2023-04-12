namespace exercise_2
{// 1. Задача. Немає взаємозв'язку між класами башта та user. Але воду Користувач може брати тільки в башти. Симулятор може керувати цим призначенням звідки буде братись вода. 
     //Помпа має качати автоматично воду, взаємодіючи напряму з баштою. На діаграмі цього не видно.
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("1-th");
            var input = Validator.InputSearched();
            string test1 = input.Item1; //"qwerty qwerty 123 1243 qwerty1823";
            string test1_found = input.Item2; //"123";

            var result = EditString.FindString(test1, test1_found);
            if (result == null) Console.WriteLine("Null");
            else Console.WriteLine(result);

            Console.WriteLine("\n2-th\nEnter Source string for 2-th task:");
            //string source_2 = Console.ReadLine();
            string source_2 = "(Uppercase a`'lowercase' 332423 'Upercase' Upercase (Upercase) s 5lowercase)";
            int result_2 = EditString.FindUpperCase(source_2);
            Console.WriteLine(result_2);

            Console.WriteLine("\n3-th\nEnter Source string for 3-th task:");
            string source_3 = Console.ReadLine(); //"qww    ((sasdfg 458711";
            Console.WriteLine("Enter Target string for 3-th task:");
            string target_3 = Console.ReadLine(); //"AAAAAAAAAAAAAAAA";
            string result_3 = EditString.ReplaceDouble(source_3, target_3);
            Console.WriteLine(result_3);
        }
    }
}
