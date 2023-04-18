
namespace exercise_2
{
    internal static class GenerateExamples
    {
        public static Item GenerateSilpo()
        {
            //Console.WriteLine("Hello, World! SilpoExample");
            Item SilpoExample = new Item(true, "SilpoExample");

            Item meat = new Item(true, "Meat");
            Item vegatebles = new Item(true, "Vegatebles");
            Item onion = new Item(false, "Onion", 50, 60, 180);
            Item pork = new Item(false, "Pork", 150, 460, 150);
            Item beef = new Item(false, "Beef", 100, 166, 205);
            vegatebles.PutItem(onion);

            meat.PutItem(pork);
            meat.PutItem(beef);

            SilpoExample.PutItem(meat);
            SilpoExample.PutItem(vegatebles);

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
            SilpoExample.PutItem(household);

            SilpoExample.SetItemInDepart("Organic_Detergents", new Item(false, "Vanish", 128, 230, 50));
            
            //Console.WriteLine(SilpoExample.Print(0));
            //Console.WriteLine(new string('-', 100));
            return SilpoExample;
        }

        public static Item GenerateATB()
        {
            //Console.WriteLine("Hello, World! ATB");
            Item ATBExample = new Item(true, "ATB");

            string custom_path = "Household/Detergents/Organic_Detergents";
            ATBExample.CreatePath(custom_path.Split('/'), 0);
            string custom_path2 = "Household/Detergents/Synthetic_Detergents";
            ATBExample.CreatePath(custom_path2.Split('/'), 0);

            ATBExample.SetItemInDepart("Synthetic_Detergents", new Item(false, "Vanish_synthetic", 128, 230, 50));
            ATBExample.SetItemInDepart("Organic_Detergents", new Item(false, "Vanish", 128, 230, 50));
            //Console.WriteLine(ATBExample.Print(0));
            //Console.WriteLine(new string('-', 100));
            return ATBExample;
        }
    }
}
