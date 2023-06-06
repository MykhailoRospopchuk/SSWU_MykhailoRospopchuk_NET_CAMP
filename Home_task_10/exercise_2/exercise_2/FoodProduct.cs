//A specific class responsible for Food products
namespace exercise_2
{
    internal class FoodProduct : Product
    {
        public FoodProduct(int id, string name, ProductType type, int length, int width, int height, decimal weight) 
            : base(id, name, type, length, width, height, weight)
        {
        }

        //We override the base method of receiving the Visitor instance for Food product
        public override decimal AcceptVisitor(IDeliveryCalculator visitor)
        {
            return visitor.VisitFoodProduct(this);
        }
    }
}
