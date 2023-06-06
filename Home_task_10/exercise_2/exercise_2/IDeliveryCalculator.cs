//The interface that determines the behavior of the Visitor
namespace exercise_2
{
    internal interface IDeliveryCalculator
    {
        decimal VisitProduct(IProduct product);
        decimal VisitFoodProduct(FoodProduct product);
        decimal VisitElectronicsProduct(ElectronicsProduct product);
        decimal VisitClothesProduct(ClothesProduct product);
        decimal VisitHouseholdProduct(HouseholdProduct product);
        decimal VisitHygieneProduct(HygieneProduct product);
        decimal VisitAppliancesProduct(AppliancesProduct product);
    }
}