//The traffic light acts as an observer. Implements the ITrafficLightObserver and IClonable<TrafficLight> interfaces.
using System.Text;

namespace exercise_b
{
    internal class TrafficLight : ITrafficLightObserver, IClonable<TrafficLight>
    {
        private int _type;
        private int _id;
        private readonly int _number;
        private int _state;
        public TrafficLight(int number, int id, int type)
        {
            _number = number;
            _id = id;
            _type = type;
            _state = _type == 1 ? 1 : 222;
        }
        public int Type
        {
            get { return _type; }
        }
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        //The Update method performs the main function of changing the state of the observer
        //in accordance with the change of the state of the subject.
        //In the case of creating new types of observer,
        //the Update method will be refactored according to the mechanism of operation of the new type.
        public async Task UpdateAsync(int value, int yellow_duration_second)
        {
            if (value != _state)
            {
                if (value < 10)
                {
                    if (Math.Abs(value - _state) > 1)
                    {
                        _state = 2;
                        await Task.Delay(yellow_duration_second);
                    }
                    _state = value;
                }
                else
                {
                    await ColorParserAsync(value, yellow_duration_second);
                }
            }
        }

        private async Task ColorParserAsync(int value, int yellow_duration_second)
        {
            List<int> current = _state.ToString().Select(digit => int.Parse(digit.ToString())).ToList();
            List<int> income = value.ToString().Select(digit => int.Parse(digit.ToString())).ToList();

            int result = 0;
            int bias = 1;
            int length = current.Count;
            bool repit = false;

            for (int i = length - 1; i >= 0; i--)
            {
                if (Math.Abs(current[i] - income[i]) > 1)
                {
                    result += 2 * bias;
                    repit = true;
                }
                else
                {
                    result += income[i] * bias;
                }
                bias *= 10;
            }
            if (repit)
            {
                _state = result;
                await Task.Delay(yellow_duration_second);
                await ColorParserAsync(value, yellow_duration_second);
            }
            else
            {
                _state = result;
            }
        }

        public object GetState()
        {
            return new { ID = _id, Number = _number, State = _state };
        }

        public override string? ToString()
        {
            return $"|{_id}:{_number}:{_type}:{_state}";
        }

        public TrafficLight Clone()
        {
            return new TrafficLight(_number, _id, _type);
        }


    }
}
