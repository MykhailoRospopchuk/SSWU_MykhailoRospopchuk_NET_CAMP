//A specific class responsible for clothing products
namespace exercise_2
{
    internal class ClothesProduct : Product
    {
        public ClothesProduct(int id, string name, ProductType type, int length, int width, int height, decimal weight)
            : base(id, name, type, length, width, height, weight)
        {
        }

        //We override the base method of receiving the Visitor instance for Clothes product
        public override decimal AcceptVisitor(IDeliveryCalculator visitor)
        {
            return visitor.VisitClothesProduct(this);
        }
    }
}
