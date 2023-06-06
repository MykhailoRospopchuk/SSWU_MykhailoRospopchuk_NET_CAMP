//Basic product class.
//It carries functions and is responsible for the basic behavior of all kinds of products
namespace exercise_2
{
    internal class Product : IProduct
    {
        private readonly int _id;
        private readonly string _name;
        private readonly ProductType _type;
        private readonly int _length;
        private readonly int _width;
        private readonly int _height;
        private readonly decimal _weight;

        private readonly decimal _capacity;

        public Product(int id, string name, ProductType type, int length, int width, int height, decimal weight)
        {
            _id = id;
            _name = name;
            _type = type;
            _length = length;
            _width = width;
            _height = height;
            _weight = weight;

            _capacity = length * height * weight;
        }

        public int Id { get { return _id; } }
        public decimal Capacity { get { return _capacity; } }
        public decimal Weight { get { return _weight; } }

        //Returns the largest product size
        public decimal GetMaxMeasurement()
        {
            return Math.Max(_length, Math.Max(_width, _height));
        }
        //Returns the smallest product size
        public decimal GetMinMeasurement()
        {
            return Math.Min(_length, Math.Min(_width, _height));
        }

        //Checks the ID of the current item's delivery features with the input data
        public bool CheckPossibleFeatures(int[] income)
        {
            bool is_contain = true;
            int[] current = _type.Possible_Features;
            foreach (var item in income)
            {
                if (!current.Contains(item))
                {
                    is_contain = false;
                }
            }

            return is_contain;
        }

        //Implementation of the pattern Visitor. Accepts an instance of a visitor
        //This method is basic for all product classes that will be inherited from the base class
        public virtual decimal AcceptVisitor(IDeliveryCalculator visitor)
        {
            return visitor.VisitProduct(this);
        }

        public override string ToString()
        {
            return $"Product Id: {_id,4}; Name: {_name,15}; Product Type: {_type.TypeName, 20}; Capacity: {_capacity * (decimal)Math.Pow(10,-6),15:F6} cm3; Weight: {_weight,3}";
        }
    }
}
