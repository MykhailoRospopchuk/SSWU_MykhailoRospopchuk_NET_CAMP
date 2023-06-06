//A specific class responsible for electronic products
namespace exercise_2
{
    internal class ElectronicsProduct : Product
    {
        public ElectronicsProduct(int id, string name, ProductType type, int length, int width, int height, decimal weight)
            : base(id, name, type, length, width, height, weight)
        {
        }

        //We override the base method of receiving the Visitor instance for Electronic product
        public override decimal AcceptVisitor(IDeliveryCalculator visitor)
        {
            return visitor.VisitElectronicsProduct(this);
        }
    }
}
