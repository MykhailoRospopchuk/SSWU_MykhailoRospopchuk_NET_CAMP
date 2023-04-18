
namespace exercise_2
{
    internal static class Menu
    {
        private static LocalStorage _storage = null;

        //Save the menu options that will be displayed on the screen
        private static string[] _options = {
            "1 - Show examples of created supermarkets",
            "2 - Create new Supermarket",
            "3 - Show list of Supermarkets",
            "4 - Create a structure in a supermarket",
            "5 - Add product to department",
            "6 - Show created Supermarkets",
            "7 - Exit"
        };

        //The method displays the list of options on the screen
        private static void PrintMenu()
        {
            Console.WriteLine("--------------MENU--------------");
            foreach (var item in _options)
            {
                Console.WriteLine(item);
            }
        }

        //The main method in the menu, which calls the corresponding methods according to the user's selection
        public static void MainMenu(LocalStorage storage)
        {
            _storage = storage;
            InitExamples();
            int user_option = 0;
            while (true)
            {
                
                PrintMenu();//Display a list of options
                try
                {
                    user_option = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException)
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
                        ShowExamples();
                        break;
                    case 2:
                        CreateNewSupermarket();
                        break;
                    case 3:
                        ShowListSupermarkets();
                        break;
                    case 4:
                        CreateStructureSupermarket();
                        break;
                    case 5:
                        AddProductToDepartment();
                        break;
                    case 6:
                        ShowCreatedSupermarkets();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter an integer value between 1 and " + _options.Length + "or 7 for exit");
                        break;
                }
            }
        }

        private static void InitExamples()
        {
            Item SilpoExample = GenerateExamples.GenerateSilpo();
            Item ATBExample = GenerateExamples.GenerateATB();
            _storage.SupermarcetExamples = SilpoExample;
            _storage.SupermarcetExamples = ATBExample;
        }

        private static void ShowExamples()
        {
            Item SilpoExample = _storage.GetExamplesSupermarketById(0);
            Console.WriteLine("Hello, World! SilpoExample");
            Console.WriteLine(SilpoExample.Print(0));
            Console.WriteLine(new string('-', 100));

            Item ATBExample = _storage.GetExamplesSupermarketById(1);
            Console.WriteLine("Hello, World! ATBExample");
            Console.WriteLine(ATBExample.Print(0));
            Console.WriteLine(new string('-', 100));
        }

        private static void CreateNewSupermarket()
        {
            try
            {
                Console.WriteLine("Enter name of Your Supermarket");
                string name_supermarket = Console.ReadLine();
                Item market = new Item(true, name_supermarket);
                _storage.Supermarcet = market;
                Console.WriteLine($"Market - {name_supermarket} successfully created");
                Console.WriteLine(market.Print(0));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void ShowListSupermarkets()
        {
            _storage.PrintSupermarket();
        }

        private static void CreateStructureSupermarket()
        {
            try
            {
                Console.WriteLine("Select a supermarket from the list");
                _storage.PrintSupermarket();
                int id_market = Convert.ToInt32(Console.ReadLine());
                Item current_market = _storage.GetSupermarketById(id_market);
                Console.WriteLine("Enter the store department structure, separated by \"/\"");
                string custom_path = Console.ReadLine();
                current_market.CreatePath(custom_path.Split('/'), 0);
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please enter an integer value");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void AddProductToDepartment()
        {
            try
            {
                Console.WriteLine("Select a supermarket from the list");
                _storage.PrintSupermarket();
                int id_market = Convert.ToInt32(Console.ReadLine());
                Item current_market = _storage.GetSupermarketById(id_market);
                Console.WriteLine($"Market - {current_market.Title}");
                Console.WriteLine(current_market.Print(0));

                Console.WriteLine("Enter the name of Product:");
                string product_name = Console.ReadLine();

                Console.WriteLine("Enter the Department in which the Product will be located:");
                string product_department = Console.ReadLine();

                Console.WriteLine("Enter the Height of Product:");
                int product_height = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the Width of Product:");
                int product_width = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the Lenght of Product:");
                int product_lenght = Convert.ToInt32(Console.ReadLine());

                var result = current_market.SetItemInDepart(product_department, new Item(false, product_name, product_lenght, product_height, product_width));
                if (result == null)
                {
                    throw new Exception("Something went wrong");
                }
                Console.WriteLine($"Market - {current_market.Title}");
                Console.WriteLine(current_market.Print(0));
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please enter an integer value");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void ShowCreatedSupermarkets()
        {
            try
            {
                if (_storage.IsSupermarketListEmpty())
                {
                    Console.WriteLine("You have not created any supermarket yet!\nCreate a new supermarket using a menu");
                }
                else
                {
                    Console.WriteLine("Select a supermarket from the list");
                    _storage.PrintSupermarket();
                    int id_market = Convert.ToInt32(Console.ReadLine());
                    Item current_market = _storage.GetSupermarketById(id_market);
                    Console.WriteLine($"Market - {current_market.Title}");
                    Console.WriteLine(current_market.Print(0));
                }
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Please enter an integer value");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
