using System.Threading.Channels;

namespace exercise_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            DB.InitDB();
            
            AbstractHandler exist_handler = new ExistsBrandBankHandler();
            AbstractHandler luna_handler = new LunaHandler();
            AbstractHandler rule_handler = new RuleBankCheckHandler();


            exist_handler.SetNext(luna_handler).SetNext(rule_handler);

            TerminalOfValidation terminal = new TerminalOfValidation(exist_handler);

            terminal.MainMenu();
        }
    }
}