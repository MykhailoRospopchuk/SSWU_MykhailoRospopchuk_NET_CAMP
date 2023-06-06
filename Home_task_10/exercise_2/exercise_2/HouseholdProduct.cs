//A specific class responsible for household products
namespace exercise_2
{
    internal class HouseholdProduct : Product
    {
        public HouseholdProduct(int id, string name, ProductType type, int length, int width, int height, decimal weight)
            : base(id, name, type, length, width, height, weight)
        {
        }

        //We override the base method of receiving the Visitor instance for Household product
        public override decimal AcceptVisitor(IDeliveryCalculator visitor)
        {
            return visitor.VisitHouseholdProduct(this);
        }
    }
}
