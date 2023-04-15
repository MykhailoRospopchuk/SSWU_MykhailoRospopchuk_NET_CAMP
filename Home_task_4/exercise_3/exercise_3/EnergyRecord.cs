//  This class models a single record from a quarter
//  If there are no measurements for a certain month, they are filled with default values
//  Two constructors have been created to accept both named arguments and an array of strings

namespace exercise_3
{
    internal class EnergyRecord
    {
        private int _apart_number;
        private string _apart_address;
        private string _apart_surname;
        private int _value_month_1;
        private int _value_month_2;
        private int _value_month_3;
        private DateTime _measurements_date_month_1;
        private DateTime _measurements_date_month_2;
        private DateTime _measurements_date_month_3;

        public EnergyRecord(int apart_num, string address, string surname, int in_value_month_1 = 0, int in_value_month_2 = 0, int in_value_month_3 = 0, DateTime measur_date_month_1 = new DateTime(), DateTime measur_date_month_2 = new DateTime(), DateTime measur_date_month_3 = new DateTime())
        {
            _apart_number = apart_num;
            _apart_address = address;
            _apart_surname = surname;
            _value_month_1 = in_value_month_1;
            _value_month_2 = in_value_month_2;
            _value_month_3 = in_value_month_3;
            _measurements_date_month_1 = in_value_month_1 == 0 ? new DateTime() : measur_date_month_1;
            _measurements_date_month_2 = in_value_month_2 == 0 ? new DateTime() : measur_date_month_2;
            _measurements_date_month_3 = in_value_month_3 == 0 ? new DateTime() : measur_date_month_3;
        }
        public EnergyRecord(string[] input)
        {
            _apart_number = Convert.ToInt32(input[0]);
            _apart_address = input[1];
            _apart_surname = input[2];
            _value_month_1 = input[3].Length == 0 ? 0 : Convert.ToInt32(input[3]);
            _value_month_2 = input[4].Length == 0 ? 0 : Convert.ToInt32(input[4]);
            _value_month_3 = input[5].Length == 0 ? 0 : Convert.ToInt32(input[5]);
            _measurements_date_month_1 = input[6].Length == 0 || _value_month_1 == 0 ? new DateTime() : DateTime.Parse(input[6]);
            _measurements_date_month_2 = input[7].Length == 0 || _value_month_2 == 0 ? new DateTime() : DateTime.Parse(input[7]);
            _measurements_date_month_3 = input[8].Length == 0 || _value_month_3 == 0 ? new DateTime() : DateTime.Parse(input[8]);
        }

        public int Id
        {
            get { return _apart_number; }
        }
        public string Address
        {
            get { return _apart_address; }
        }
        public string Surname
        {
            get { return _apart_surname; }
        }
        public int IncomMonth1
        {
            get { return _value_month_1; }
        }
        public int IncomMonth2
        {
            get { return _value_month_2; }
        }
        public int IncomMonth3
        {
            get { return _value_month_3; }
        }
        public DateTime MeasurDate1
        {
            get { return _measurements_date_month_1; }
        }
        public DateTime MeasurDate2
        {
            get { return _measurements_date_month_2; }
        }
        public DateTime MeasurDate3
        {
            get { return _measurements_date_month_3; }
        }

        //Finds the value of the total debt for one record.
        //Uses the currency rate value from the static class Currency.
        public double SumDept()
        {
            double debt = 0;
            double exchange_rate = Currency.GetCurrency();
            if (_value_month_3 != 0)
            {
                debt += _value_month_3 - _value_month_2;
            }
            if (_value_month_2 != 0)
            {
                debt += _value_month_2 - _value_month_1;
            }
            return debt * exchange_rate;
        }

        //Calculates the number of days since the last measurement.
        public double GetTimeSpend()
        {
            double result = _measurements_date_month_3 == default ? (_measurements_date_month_2 == default ? (_measurements_date_month_2 == default ? 0 : (DateTime.Now - _measurements_date_month_1).TotalDays) : (DateTime.Now - _measurements_date_month_2).TotalDays) : (DateTime.Now - _measurements_date_month_3).TotalDays;
            return result;
        }

        //Returns a string that will be written directly to a text file.
        public string GetStingToWrite()
        {
            string date_1 = _measurements_date_month_1 == default ? "" : _measurements_date_month_1.ToString("dd.MM.yyyy");
            string date_2 = _measurements_date_month_2 == default ? "" : _measurements_date_month_2.ToString("dd.MM.yyyy");
            string date_3 = _measurements_date_month_3 == default ? "" : _measurements_date_month_3.ToString("dd.MM.yyyy");

            string result = $"{_apart_number};{_apart_address};{_apart_surname};{_value_month_1};{_value_month_2};{_value_month_3};{date_1};{date_2};{date_3};";
            return result;
        }

        public override string ToString()
        {
            string date_1 = _measurements_date_month_1 == default ? "" : _measurements_date_month_1.ToString("dd.MM.yyyy");
            string date_2 = _measurements_date_month_2 == default ? "" : _measurements_date_month_2.ToString("dd.MM.yyyy");
            string date_3 = _measurements_date_month_3 == default ? "" : _measurements_date_month_3.ToString("dd.MM.yyyy");

            string item = $"Apartment number: {_apart_number}; Address: {_apart_address}; Surname: {_apart_surname}; Measurements 1: {_value_month_1}; Measurements 2: {_value_month_2}; Measurements 3: {_value_month_3}; Measurements date: {date_1}, {date_2}, {date_3};";
            return item;
        }

    }
}
