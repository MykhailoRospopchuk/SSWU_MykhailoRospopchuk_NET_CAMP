namespace exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Item Silpo = new Item(true, "Silpo");
            
            Item meat = new Item(true, "Meat");
            Item vegatebles = new Item(true, "Vegatebles");
            Item onion = new Item(false, "Onion", 50, 60, 180);
            Item pork = new Item(false, "Pork", 150, 460, 150);
            Item beef = new Item(false, "Beef", 100, 166, 205);
            vegatebles.PutItem(onion);

            meat.PutItem(pork);
            meat.PutItem(beef);

            Silpo.PutItem(meat);
            Silpo.PutItem(vegatebles);

            Item household = new Item(true, "Household");
            Item detergents = new Item(true, "Detergents");
            Item organic_detergents = new Item(true, "Organic_Detergents");
            Item tite = new Item(false, "Tite", 450, 156, 77);

            Item gala = new Item(false, "Gala", 350, 186, 95);


            organic_detergents.PutItem(tite);
            organic_detergents.PutItem(gala);
            detergents.PutItem(organic_detergents);
            detergents.PutItem(gala);
            household.PutItem(detergents);
            Silpo.PutItem(household);

            Console.WriteLine(Silpo.Print(0));

            
            var res = Silpo.SetItemInDepart("Organic_Detergents", new Item(false, "Vanish", 128, 230, 50));

            Console.WriteLine(res.Print(0));

            Console.WriteLine(new string('-', 50));
            Console.WriteLine(Silpo.Print(0));


            Console.WriteLine("Hello, World! ATB");
            Item ATB = new Item(true, "ATB");
            string custom_path = "Household/Detergents/Organic_Detergents";
            ATB.CreatePath(custom_path.Split('/'), 0);
            Console.WriteLine(ATB.Print(0));
            string custom_path2 = "Household/Detergents/Synthetic_Detergents";
            ATB.CreatePath(custom_path2.Split('/'), 0);
            Console.WriteLine(ATB.Print(0));

            ATB.SetItemInDepart("Synthetic_Detergents", new Item(false, "Vanish_synt", 128, 230, 50));
            ATB.SetItemInDepart("Organic_Detergents", new Item(false, "Vanish", 128, 230, 50));
            Console.WriteLine(ATB.Print(0));
        }
    }
}