
namespace exercise_1
{
    internal static class BankBrands
    {
        private static List<Bank> _bank_brand;

        static BankBrands()
        {
            List<string> brand_from_db = DB.GetAllLine(DB.PathData._bank_brand_path);

            _bank_brand = ParseBrand(brand_from_db);
        }

        public static List<Bank> GetBank()
        {
            return _bank_brand; 
        }

        private static List<Bank> ParseBrand(List<string> brand)
        {
            List<Bank> result = new List<Bank>();
            foreach (var item in brand)
            {
                result.Add(BankParser.Parse(item));
            }
            return result;
        }

        public static Bank GetBankByBrand(string name)
        {
            return _bank_brand.Find(bank => bank.BankName == name);
        }

        public static void UpdateBrand()
        {
            List<string> brand_from_db = DB.GetAllLine(DB.PathData._bank_brand_path);
            _bank_brand = ParseBrand(brand_from_db);
        }

        public static bool CheckBrand(string bank_name)
        {
            return _bank_brand.Exists(bank => bank.BankName == bank_name);
        }

        public static void ClearBrandList()
        {
            _bank_brand.Clear();
        }

        public static void AddBrand(Bank income_bank)
        {
            if (income_bank != null)
            {
                DB.WriteLine(income_bank.ToString(), DB.PathData._bank_brand_path);
                UpdateBrand();
            }
        }
    }
}
