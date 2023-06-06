//The class is responsible for parsing data read from files and communication between entities.
//When loading an entity that contains other entities, it loads them from text files
//It partially performs the function of validating the read data
namespace exercise_2
{
    internal static class DataLoader
    {
        //The class loads a line about the product type from a text file and performs its parsing
        public static ProductType ProductTypeLoad(int income_id)
        {
            ProductType result;

            string income = DB.GetLine(income_id, DB.PathData._type_path);
            if (income == null)
            {
                return null;
            }

            try
            {
                string[] types = income.Split(';');

                int id = Convert.ToInt32(types[0]);
                string name = types[1];
                int[] features = types[2].Split(" ").Select(int.Parse).ToArray();
                decimal discount = Convert.ToDecimal(types[3]);

                result = new ProductType(id, name, features, discount);
                
            }
            catch (FormatException)
            {
                result = null;
                Console.WriteLine($"Input format for Product Type with ID: {income_id} - IS INCORRECT. Check the table //type_product.txt//");
            }

            return result;
        }

        //The class loads a line about the product from a text file by ID and performs its parsing.
        //Uploads an entity about the product type
        public static IProduct ProductLoad(int income_id)
        {
            IProduct result;

            string income = DB.GetLine(income_id, DB.PathData._product_path);
            if (income == null)
            {
                return null;
            }

            try
            {
                string[] products = income.Split(";");

                int id = Convert.ToInt32(products[0]);
                string name = products[1];
                int type_id = Convert.ToInt32(products[2]);
                int length = Convert.ToInt32(products[3]);
                int width = Convert.ToInt32(products[4]);
                int height = Convert.ToInt32(products[5]);
                decimal weight = Convert.ToDecimal(products[6]);

                ProductType current_type = ProductTypeLoad(type_id);

                if (current_type == null)
                {
                    result = null;
                }
                else
                {
                    result = CreateProduct(id, name, current_type, length, width, height, weight);
                }
            }
            catch (FormatException)
            {
                result = null;
                View.PrintExceptionMessage($"Input format for Product with ID: {income_id} - //{income}// - IS INCORRECT. Check the table //product.txt//");
            }
            return result;
        }

        //The class loads a line about delivery features from a text file and performs its parsing
        public static FeaturesProduct FeaturesProductLoad(int income_id)
        {
            FeaturesProduct result;

            string income = DB.GetLine(income_id, DB.PathData._features_path);
            if (income == null)
            {
                return null;
            }

            try
            {
                string[] features = income.Split(";");

                int id = Convert.ToInt32(features[0]);
                string name = features[1];
                decimal coefficient = Convert.ToDecimal(features[2]);
                decimal additional_price = Convert.ToDecimal(features[3]);

                result = new FeaturesProduct(id, name, coefficient, additional_price);
            }
            catch (FormatException)
            {
                result = null;
                Console.WriteLine($"Input format for Features Product with ID: {income_id} - IS INCORRECT. Check the table //features_product.txt//");
            }

            return result;
        }

        //Downloads the registered product in delivery according to its ID from a text file
        //For future expansion of functionality
        public static DeliveryItem DeliveryItemLoadId(int income_id)
        {
            string income = DB.GetLine(income_id, DB.PathData._delivery_path);
            if (income == null)
            {
                return null;
            }
            return DeliveryParse(income);
        }

        //Parses a string with shipping information already preloaded from a text file
        public static DeliveryItem DeliveryItemParse(string income)
        {
            if (income == null)
            {
                return null;
            }
            return DeliveryParse(income);
        }

        //A private class that directly parses the delivery string.
        //Performs the function of loading related entities
        private static DeliveryItem DeliveryParse(string income)
        {
            DeliveryItem result;

            try
            {
                string[] delivery = income.Split(";");
                int id = Convert.ToInt32(delivery[0]);
                int product_id = Convert.ToInt32(delivery[1]);

                IProduct current_prod = ProductLoad(product_id);

                if (current_prod == null)
                {
                    throw new FormatException($"There is something wrong with Product with ID: {product_id}");
                }

                int[] features_id = delivery[2].Split(" ").Select(int.Parse).ToArray();
                FeaturesProduct[] features = new FeaturesProduct[features_id.Length];
                for (int i = 0; i < features_id.Length; i++)
                {
                    if (features_id[i] == 0)
                    {
                        features[i] = new FeaturesProduct(0, "Has no factors", 1m, 0m);
                    }
                    else
                    {
                        var temp = FeaturesProductLoad(features_id[i]);
                        if (temp == null)
                        {
                            throw new FormatException($"There is no Features with ID: {features_id[i]}");
                        }
                        features[i] = temp;
                    }
                }

                result = new DeliveryItem(id, current_prod);
                result.SetFeatures(features);
            }
            catch (FormatException ex)
            {
                result = null;
                View.PrintExceptionMessage(ex.Message);
                View.PrintExceptionMessage($"Input format for Delivery Product : //{income}// - IS INCORRECT. Check the table //delivery_product.txt//\n");
            }
            
            return result;
        }

        //A private class that creates an instance of a product according to its type
        private static IProduct CreateProduct(int id, string name, ProductType current_type, int length, int width, int height, decimal weight)
        {
            switch (current_type.Id)
            {
                case 1:
                    return new FoodProduct(id, name, current_type, length, width, height, weight);
                case 2:
                    return new ElectronicsProduct(id, name, current_type, length, width, height, weight);
                case 3:
                    return new ClothesProduct(id, name, current_type, length, width, height, weight);
                case 4:
                    return new HouseholdProduct(id, name, current_type, length, width, height, weight);
                case 5:
                    return new HygieneProduct(id, name, current_type, length, width, height, weight);
                case 6:
                    return new AppliancesProduct(id, name, current_type, length, width, height, weight);
                default:
                    break;
            }
            return null;
        }
    }
}
