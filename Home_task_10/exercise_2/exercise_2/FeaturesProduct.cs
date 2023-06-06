//The class describes the possibilities that affect the cost of delivery.
//Store information about the ratio to the basic delivery price and additional costs
namespace exercise_2
{
    internal class FeaturesProduct
    {
        private readonly int _id;
        private readonly string _name;
        private readonly decimal _coefficient;
        private readonly decimal _additional_price;

        public FeaturesProduct(int id, string name, decimal coefficient, decimal additional_price)
        {
            _id = id;
            _name = name;
            _coefficient = coefficient;
            _additional_price = additional_price;
        }

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public decimal Coefficient { get { return _coefficient; } }
        public decimal Additional_Price { get { return _additional_price; } }

        public override string ToString()
        {
            return $"Id: {_id,4}; Name: {_name}; Coefficient {_coefficient}; Additional Price: {_additional_price}";
        }
    }
}
