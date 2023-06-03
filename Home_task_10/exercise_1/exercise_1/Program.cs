//Credit card validation is built on the "Chain of Responsibilities" pattern
namespace exercise_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //Creation of three links in the chain of responsibility
            //  ExistsBrandBankHandler - Checks for the existence of the credit card brand in the database
            //  LunaHandler - Verification of the card number by the Luna algorithm
            //  RuleBankCheckHandler - Checking the card number for compliance with the specified conditions according to the card brand:
            //      - number of characters and possible prefixes
            AbstractHandler exist_handler = new ExistsBrandBankHandler();
            AbstractHandler luna_handler = new LunaHandler();
            AbstractHandler rule_handler = new RuleBankCheckHandler();

            //Creating a chain of responsibility
            exist_handler.SetNext(luna_handler).SetNext(rule_handler);

            //Creating an instance of the client that will use the chain of responsibility
            TerminalOfValidation terminal = new TerminalOfValidation(exist_handler);

            //Entering the application menu
            terminal.MainMenu();
        }
    }
}
