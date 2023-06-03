//This class performs the function of interaction with the user.
//Organizes the execution of functions called by the user
namespace exercise_1
{
    internal class TerminalOfValidation
    {
        private readonly AbstractHandler validator_handler;

        private string[] _options = {
            "1 - Validate Card From File",
            "2 - Validate Card From Console",
            "3 - Add Card Brand",
            "4 - Show All Brands",
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

        //Verification of credit cards found in a text file
        //And displays in the console a list of all cards that passed and did not pass validation
        //If the information about the card is entered in an incorrect format
        //Message will be displayed and the card will be skipped
        public void ValidateCardFromFile()
        {
            try
            {
                List<string> list = DB.GetAllLine(DB.PathData._card_income_path);
                List<ICard> cards = new List<ICard>();

                list.ForEach(x => {
                    ICard current = CardParser.Parse(x);
                    if (current != null)
                    {
                        cards.Add(CardParser.Parse(x));
                    }
                    
                });

                cards.ForEach(card => validator_handler.Handle(card));
                View.PrintAllCard(cards);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Validation of credit card information entered by the user from the console
        //If the information about the card is entered in an incorrect format
        //Message will be displayed and the card will be skipped
        public void ValidateCardFromConsole()
        {
            try
            {
                Console.WriteLine("Enter Card data in format <<# CARD BRAND # card_number = \"CARD NUMBER\">>");
                string input_card = Console.ReadLine();

                ICard current_card = CardParser.Parse(input_card);
                if (current_card != null)
                {
                    validator_handler.Handle(current_card);

                    View.PrintCard(current_card);
                }
                
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Add a new card brand to the list of registered ones
        //If the brand information is entered incorrectly, a message will be displayed.
        //If the entered brand already exists, a message will be displayed and the brand will not be added
        public void AddBankBrand()
        {
            try
            {
                Console.WriteLine("Enter Bank data in format <<#CARD BRAND#CREDIT CARD NUMBER LENGTH#IDENTIFICATION NUMBER PREFIX>>");
                string input_brand = Console.ReadLine();
                Brand current_bank = BrandParser.Parse(input_brand);
                CardBrands.AddBrand(current_bank);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Show a list of all registered card brands
        public void ShowAllBank()
        {
            try
            {
                List<Brand> result = CardBrands.GetBank();
                View.PrintAllBank(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
