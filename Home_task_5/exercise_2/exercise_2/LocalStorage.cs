
namespace exercise_2
{
    internal class LocalStorage
    {
        private List<Item> _supermarket = new List<Item>();
        private List<Item> _supermarket_examples = new List<Item>();

        public Item Supermarcet
        {
            set { _supermarket.Add(value); }
        }

        public Item SupermarcetExamples
        {
            set { _supermarket_examples.Add(value); }
        }

        public bool IsSupermarketListEmpty()
        {
            if (_supermarket.Count() == 0)
            {
                return true;
            }
            return false;
        }
        public void PrintSupermarket()
        {
            int counter = 0;
            Console.WriteLine("List of Supermarkets");
            _supermarket.ForEach(item => {
                Console.WriteLine($"{counter} - {item.Title}");
                counter++;
            });
        }
        public void PrintSupermarketExamples()
        {
            int counter = 0;
            Console.WriteLine("List of Examples Supermarkets");
            _supermarket_examples.ForEach(item => {
                Console.WriteLine($"{counter} - {item.Title}");
                counter++;
            });
        }

        public Item GetSupermarketById(int id)
        {
            if ( _supermarket.Count < id )
                throw new ArgumentNullException();
            return _supermarket[id];
        }

        public Item GetExamplesSupermarketById(int id)
        {
            if (_supermarket_examples.Count < id)
                throw new ArgumentNullException();
            return _supermarket_examples[id];
        }
    }
}
