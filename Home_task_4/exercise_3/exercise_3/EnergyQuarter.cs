//  The class models the essence of the quarter in the program
//  Stores data on the number of entries in the quarter,
//the quarter number and the list of months of the quarter
//  It has two constructors for creation - directly by entering arguments and the second one that accepts an array of strings
using System.Globalization;
using System.Text;

namespace exercise_3
{
    internal class EnergyQuarter
    {
        private int _consumer_count;
        private int _quarter_number;
        private List<string> _quarter_month = new List<string>();

        public EnergyQuarter(int quarter_number)
        {
            _consumer_count = 0;
            _quarter_number = quarter_number;
            CreateQuaerter(_quarter_number);
        }

        public EnergyQuarter(string[] input)
        {
            _consumer_count = Convert.ToInt32(input[0]);
            _quarter_number = Convert.ToInt32(input[1]);
            CreateQuaerter(_quarter_number);
        }

        //Creates a list of quarter months according to the quarter number
        private void CreateQuaerter(int quarter)
        {
            _quarter_month.Add((new DateTime(DateTime.Now.Year, quarter * 3 - 2, 1)).ToString("MMMM", CultureInfo.GetCultureInfo("en-US")));
            _quarter_month.Add((new DateTime(DateTime.Now.Year, quarter * 3 - 1, 1)).ToString("MMMM", CultureInfo.GetCultureInfo("en-US")));
            _quarter_month.Add((new DateTime(DateTime.Now.Year, quarter * 3, 1)).ToString("MMMM", CultureInfo.GetCultureInfo("en-US")));
        }

        public int CountConsumer { get { return _consumer_count; } set { _consumer_count = value; } }
        public int QuarterNumber { get { return _quarter_number; } }
        public List<string> Month { get { return _quarter_month; } }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Number of consumers: {_consumer_count}; Quarter number: {_quarter_number}; Months of the quarter:");
            _quarter_month.ForEach(x => sb.Append(' ' + x + ';'));
            return sb.ToString();
        }
    }
}
