using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DataWorker
{
    struct StateRecord
    {
        public int Crossroad_Number;
        public int Traficligh_Number;
        public int Traficligh_Type;
        public int Traficligh_State;

        public StateRecord(int crossroad_Number, int traficligh_Number, int traficligh_Type, int traficligh_State)
        {
            Crossroad_Number = crossroad_Number;
            Traficligh_Number = traficligh_Number;
            Traficligh_Type = traficligh_Type;
            Traficligh_State = traficligh_State;
        }

        public string GetMarker()
        {
            return $"{Crossroad_Number}-{Traficligh_Number}";
        }
    }
}
