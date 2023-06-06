//A specific class that is responsible for household appliances products
namespace exercise_2
{
    internal class AppliancesProduct : Product
    {
        public AppliancesProduct(int id, string name, ProductType type, int length, int width, int height, decimal weight)
            : base(id, name, type, length, width, height, weight)
        {
        }

        //We override the base method of receiving the Visitor instance for Appliance product
        public override decimal AcceptVisitor(IDeliveryCalculator visitor)
        {
            return visitor.VisitAppliancesProduct(this);
        }
    }
}
