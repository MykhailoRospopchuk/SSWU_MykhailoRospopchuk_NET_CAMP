//A class that implements the behavior of the Visitor
namespace exercise_2
{
    internal class DeliveryCalculator : IDeliveryCalculator
    {
        private Random random = new Random();

        //For each class of products, a specific method of calculating the cost of delivery is performed
        //

        public decimal VisitAppliancesProduct(AppliancesProduct product)
        {
            decimal delivery_cost = product.Capacity /  product.Weight / product.GetMaxMeasurement() + product.GetMinMeasurement();

            return delivery_cost;
        }

        public decimal VisitClothesProduct(ClothesProduct product)
        {
            decimal delivery_cost = product.Capacity / product.Weight / 100 * 2.5m;

            return delivery_cost;
        }

        public decimal VisitElectronicsProduct(ElectronicsProduct product)
        {
            decimal delivery_cost = product.Capacity / product.Weight / 750 + 500;

            return delivery_cost;
        }

        public decimal VisitFoodProduct(FoodProduct product)
        {
            decimal delivery_cost = product.Capacity / product.Weight / 1000 * 77;

            return delivery_cost;
        }

        public decimal VisitHouseholdProduct(HouseholdProduct product)
        {
            decimal delivery_cost = product.Capacity / product.Weight / random.Next(100, 500);

            return delivery_cost;
        }

        public decimal VisitHygieneProduct(HygieneProduct product)
        {
            decimal delivery_cost = product.Capacity / product.Weight / 10000;

            return delivery_cost;
        }

        //If the child class does not have a Visitor implementation method, the method for the base class is called
        public decimal VisitProduct(IProduct product)
        {
            decimal delivery_cost = product.Capacity / product.Weight / 1000;

            return delivery_cost;
        }
    }
}
