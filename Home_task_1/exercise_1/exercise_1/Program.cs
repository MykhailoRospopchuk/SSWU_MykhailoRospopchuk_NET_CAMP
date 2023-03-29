namespace exercise_1
{
    internal class Program
    {//Вітаю. Перше завдання по створенню репозиторію Ви виконали.
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.Write("Enter number of rows: ");
            int user_rows = Convert.ToInt32(Console.ReadLine());
            
            Console.Write("Enter number of columns: ");
            int user_columns = Convert.ToInt32(Console.ReadLine());
           
            Console.Write("Enter number of start number: ");
            int user_number = Convert.ToInt32(Console.ReadLine());
            
            Snake test = new Snake(user_rows, user_columns, user_number);
            Console.WriteLine(test.ToString());//Print empty array
            
            test.SetSnakeIntoArray(true);//Fill snake array in clockwise direction
            Console.WriteLine(test.ToString());
         
            test.SetSnakeIntoArray(false);//Fill snake array in counterclockwise direction
            Console.WriteLine(test.ToString());


        }
    }
}
