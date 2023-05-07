//This class models the instructions that the user sets in the Controller subject.
namespace exercise_b
{
    internal class TrafficPeriod : IClonable<TrafficPeriod>
    {
        //Stores information about the necessary state of traffic lights at each stage of the cycle
        private readonly int[] _light_matrix;
        //Stores information about the duration of one period of green light
        private readonly int _time_period;
        //Stores information about the duration of one period of yellow light
        private readonly int _yellow_period;

        public TrafficPeriod(int[] light_matrix, int time_period, int yellow_period)
        {
            _light_matrix = light_matrix;
            _time_period = time_period * 1000;
            _yellow_period = yellow_period * 1000;
        }

        private TrafficPeriod(TrafficPeriod income)
        {
            _light_matrix = income.Ints;
            _time_period = income.Period;
            _yellow_period = income.YellowPeriod;
        }

        public int[] Ints { get { return _light_matrix; } }
        public int Period { get { return _time_period; } }
        public int YellowPeriod { get { return _yellow_period; } }

        public TrafficPeriod Clone()
        {
            return new TrafficPeriod(this);
        }
    }
}
