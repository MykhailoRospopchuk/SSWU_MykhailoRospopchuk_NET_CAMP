//The class describes the type of product, stores information about possible delivery features that affect the cost of delivery
using System.Text;

namespace exercise_2
{
    internal class ProductType
    {
        private readonly int _id;
        private readonly string _name;
        private readonly int[] _possible_features;
        private readonly decimal _discount;

        public ProductType(int id, string name, int[] possible_features, decimal discount)
        {
            _id = id;
            _name = name;
            _possible_features = possible_features;
            _discount = discount;
        }

        public int Id { get { return _id; } }
        public string TypeName { get { return _name; } }

        public int[] Possible_Features { get { return _possible_features; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Id: {_id,4}; Name: {_name,15}; Possible Features:");
            foreach (var item in _possible_features)
            {
                sb.Append("${item}");
            }
            sb.Append($"; Discount: {_discount}");
            return sb.ToString();
        }
    }
}