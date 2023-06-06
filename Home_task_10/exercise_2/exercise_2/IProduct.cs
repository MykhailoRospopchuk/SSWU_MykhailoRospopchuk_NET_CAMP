//Product interface. This interface specifies the behavior of all possible products that will be created

namespace exercise_2
{
    internal interface IProduct
    {
        decimal AcceptVisitor(IDeliveryCalculator visitor);
        int Id { get; }
        decimal Capacity { get; }
        decimal Weight { get; }

        bool CheckPossibleFeatures(int[] income);
    }
}
