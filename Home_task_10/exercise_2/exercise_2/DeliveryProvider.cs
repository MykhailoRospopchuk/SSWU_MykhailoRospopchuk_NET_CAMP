//A class that organizes all processes.
//Stores goods downloaded from files and applies the Visitor to them.
//It is essentially a client class in the Visitor pattern
using System.Text;

namespace exercise_2
{
    internal class DeliveryProvider
    {
        //All downloaded deliveries from file
        private List<DeliveryItem> _all_delivery = new List<DeliveryItem>();
        //The Visitor himself
        private readonly IDeliveryCalculator _calculator;

        public DeliveryProvider(IDeliveryCalculator calculator)
        {
            if (calculator != null)
            {
                _calculator = calculator;
            }
            
        }

        //Loading and parsing of all deliveries from a text file
        public void LoadItem()
        {
            List<string> item_from_db = DB.GetAllLine(DB.PathData._delivery_path);
            item_from_db.ForEach(x => {
                DeliveryItem temp_item = DataLoader.DeliveryItemParse(x);
                if (temp_item != null)
                {
                    _all_delivery.Add(temp_item);
                } 
            });
        }

        public void ClearItem()
        {
            _all_delivery.Clear();
        }

        //Calculation of the cost of delivery of each delivery and the total cost
        public void CalculateDelivery()
        {
            decimal total_cost = 0;
            decimal current_cost;
            decimal current_cost_full;
            StringBuilder sb = new StringBuilder();
            _all_delivery.ForEach(item =>
            {
                sb.Append($"\n{item}");
                (current_cost, current_cost_full) = item.CalculateDelivery(_calculator);
                sb.Append($"\nDelivery Cost factors: {current_cost,4:F3}");
                sb.Append($"\nDelivery Cost with additional factors: {current_cost_full,4:F3}");
                total_cost += current_cost;
                sb.Append($"\n{new string('-', 60)}");
            });

            sb.Append($"\nTotal Delivery Cost: {total_cost,4:F3}");
            View.PrintDelivery(sb.ToString());
        }
    }
}
