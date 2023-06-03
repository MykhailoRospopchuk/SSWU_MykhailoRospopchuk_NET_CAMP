//The class simulates the storage of all registered brands in the system during program execution.
//Long-term information about registered brands is stored in a text file

//In method AddBrand we can set a new card brand or add new validation rules for an already registered card type
namespace exercise_1
{
    internal static class CardBrands
    {
        private static List<Brand> _bank_brand;

        static CardBrands()
        {
            List<string> brand_from_db = DB.GetAllLine(DB.PathData._card_brand_path);

            _bank_brand = ParseAllBrand(brand_from_db);
        }

        public static List<Brand> GetBank()
        {
            return _bank_brand; 
        }

        //Parsing of all registered brands read from a text file
        private static List<Brand> ParseAllBrand(List<string> brand)
        {
            List<Brand> result = new List<Brand>();
            foreach (var item in brand)
            {
                result.Add(BrandParser.Parse(item));
            }
            return result;
        }

        //Return a brand by name in the list of registered users
        public static Brand GetBrandByName(string name)
        {
            return _bank_brand.Find(bank => bank.BrandName == name);
        }

        //Updates registered brands from a text file
        public static void UpdateBrand()
        {
            List<string> brand_from_db = DB.GetAllLine(DB.PathData._card_brand_path);
            _bank_brand = ParseAllBrand(brand_from_db);
        }

        //Check a brand by name in the list of registered users
        public static bool CheckBrand(string bank_name)
        {
            return _bank_brand.Exists(bank => bank.BrandName == bank_name);
        }

        //Clears the list of downloaded brands from the file
        public static void ClearBrandList()
        {
            _bank_brand.Clear();
        }

        //Adds a new brand to the registered list and updates the downloaded list
        //That is, we can set a new card brand or add new validation rules for an already registered card type
        public static void AddBrand(Brand income_bank)
        {
            if (income_bank != null)
            {
                if (!_bank_brand.Contains(income_bank))
                {
                    DB.WriteLine(income_bank.ToString(), DB.PathData._card_brand_path);
                    UpdateBrand();
                }
                else
                {
                    View.PrintExceptionMessage($"Already exists: {income_bank}");
                }
            }
        }
    }
}
