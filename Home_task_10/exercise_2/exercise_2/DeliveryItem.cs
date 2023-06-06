//The class models a product that is registered in the delivery system.
//Stores information about the product and its current delivery features
using System.Text;

namespace exercise_2
{
    internal class DeliveryItem
    {
        private readonly int _id;
        private readonly IProduct _product;
        private FeaturesProduct[] _featuresProduct;

        public DeliveryItem(int id, IProduct product)
        {
            _id = id;
            _product = product;
        }

        //Set an array of features of a specific product in the class
        public bool SetFeatures(FeaturesProduct[] featuresProduct)
        {
            int count_features = featuresProduct.Length;
            int[] income_features = new int[count_features];

            for (int i = 0; i < count_features; i++)
            {
                income_features[i] = featuresProduct[i].Id;
            }

            //Check whether all delivery features are possible for this product
            if (!CheckCurrentFeatures(income_features))
            {
                return false;
            }

            _featuresProduct = featuresProduct;
            return true;
        }

        private bool CheckCurrentFeatures(int[] income)
        {
            return _product.CheckPossibleFeatures(income);
        }

        //The method of calculating the cost of delivery.
        //Directly through it, we enter the instance of the visitor in concrete target
        public (decimal, decimal) CalculateDelivery(IDeliveryCalculator calculator)
        {
            decimal product_cost_delivery = _product.AcceptVisitor(calculator);
            decimal product_cost_add = 0;
            foreach (var feature in _featuresProduct)
            {
                product_cost_add = product_cost_delivery * feature.Coefficient;
                product_cost_add += feature.Additional_Price;
            }
            return (product_cost_delivery, product_cost_delivery + product_cost_add);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Delivery Item Id: {_id,4};");
            sb.Append($"\n{_product}");
            sb.Append("\nFeatures Product:");
            foreach (var item in _featuresProduct)
            {
                sb.Append($" {item.Name};");
            }
            return sb.ToString();
        }
    }
}
