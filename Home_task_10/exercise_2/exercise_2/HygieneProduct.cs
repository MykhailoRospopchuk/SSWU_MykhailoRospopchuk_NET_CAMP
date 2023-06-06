//A specific class responsible for personal hygiene products
namespace exercise_2
{
    internal class HygieneProduct : Product
    {
        public HygieneProduct(int id, string name, ProductType type, int length, int width, int height, decimal weight)
            : base(id, name, type, length, width, height, weight)
        {
        }

        //We override the base method of receiving the Visitor instance for Hygiene product
        public override decimal AcceptVisitor(IDeliveryCalculator visitor)
        {
            return visitor.VisitHygieneProduct(this);
        }
    }
}
