
using System.Threading.Channels;

namespace exercise_1
{
    internal class TerminalOfValidation
    {
        private AbstractHandler validator_handler;

        private string[] _options = {
            "1 - Validate Card From File",
            "2 - Validate Card From Console",
            "3 - Add Bank Brand",
            "4 - Show All Banks",
            "9 - Exit"
        };

        public TerminalOfValidation(AbstractHandler validator_handler)
        {
            this.validator_handler = validator_handler;
        }

        //The method displays the list of options on the screen
        private  void PrintMenu()
        {
            Console.WriteLine("--------------MENU--------------");
            foreach (var item in _options)
            {
                Console.WriteLine(item);
            }
        }


        public void MainMenu()
        {
            int user_option = 0;
            while (true)
            {
                PrintMenu();//Display a list of options
                try
                {
                    user_option = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter an integer value between 1 and " + _options.Length);
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error happened. Please try again");
                    Console.WriteLine(ex);
                    continue;
                }

                switch (user_option)
                {
                    case 1:
                        ValidateCardFromFile();
                        break;
                    case 2:
                        ValidateCardFromConsole();
                        break;
                    case 3:
                        AddBankBrand();
                        break;
                    case 4:
                        ShowAllBank();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter an integer value between 1 and " + _options.Length + "or 9 for exit");
                        break;
                }
            }
        }

        public void ValidateCardFromFile()
        {
            try
            {
                List<string> list = DB.GetAllLine(DB.PathData._card_income_path);
                List<ICard> cards = new List<ICard>();
                list.ForEach(x => cards.Add(CardParser.Parse(x)));
                cards.ForEach(card => validator_handler.Handle(card));
                View.PrintAllCard(cards);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
}

        public void ValidateCardFromConsole()
        {
            try
            {
                Console.WriteLine("Enter Card data in format <<# BANK BRAND # card_number = \"CARD NUMBER\">>");
                string input_card = Console.ReadLine();

                ICard current_card = CardParser.Parse(input_card);
                validator_handler.Handle(current_card);

                View.PrintCard(current_card);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddBankBrand()
        {
            try
            {
                Console.WriteLine("Enter Bank data in format <<#BANK BRAND#CREDIT CARD NUMBER LENGTH#IDENTIFICATION NUMBER PREFIX>>");
                string input_bank = Console.ReadLine();
                Bank current_bank = BankParser.Parse(input_bank);
                BankBrands.AddBrand(current_bank);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowAllBank()
        {
            try
            {
                List<Bank> result = BankBrands.GetBank();
                View.PrintAllBank(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
}
    }
}
