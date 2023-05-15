using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DataWorker
{
    static class DataHandler
    {
        private static string _handled_string;

        private static List<StateRecord> _stateRecords = new List<StateRecord>();

        private static string _time_record;

        public static string TimeRecord
        {
            get { return _time_record; }
        }

        public static void SetString(string income)
        {
            _handled_string = income;
            ParseData();
        }
        public static string GetString()
        {
            return _handled_string;
        }

        public static void ParseData()
        {
            _stateRecords.Clear();
            int crossroad_number;
            int traficligh_number;
            int traficligh_type;
            int traficligh_state;


            if (_handled_string != null && _handled_string != "")
            {
                string[] date_and_records = _handled_string.Split("||");
                _time_record = date_and_records[0];
                string[] str_records = date_and_records[1].Split("|");
                foreach (var item in str_records)
                {
                    string[] state_parameter = item.Split(':');
                    crossroad_number = Convert.ToInt32(state_parameter[0]);
                    traficligh_number = Convert.ToInt32(state_parameter[1]);
                    traficligh_type = Convert.ToInt32(state_parameter[2]);
                    traficligh_state = Convert.ToInt32(state_parameter[3]);
                    StateRecord current_recod = new StateRecord(crossroad_number, traficligh_number, traficligh_type, traficligh_state);
                    _stateRecords.Add(current_recod);
                }
            }
        }

        public static List<StateRecord> GetData()
        {
            return _stateRecords;
        }
    }
}
