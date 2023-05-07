//The traffic light acts as an observer. Implements the ITrafficLightObserver and IClonable<TrafficLight> interfaces.
namespace exercise_b
{
    internal class TrafficLight : ITrafficLightObserver, IClonable<TrafficLight>
    {
        private readonly int _number;
        private int _x = 0;
        private string _color = "Yellow";
        public TrafficLight(int number)
        {
            _number = number;
        }

        //The Update method performs the main function of changing the state of the observer
        //in accordance with the change of the state of the subject.
        //In the case of creating new types of observer,
        //the Update method will be refactored according to the mechanism of operation of the new type.
        public async Task Update(int value, int yellow_duration_second)
        {
            if (value != _x)
            {
                if (Math.Abs(value - _x) > 1)
                {
                    _color = "Yellow";
                    await Task.Delay(yellow_duration_second);
                }
                _x = value;
                switch (value)
                {
                    case -1:
                        _color = "Red";
                        break;
                    case 0:
                        _color = "Yellow";
                        break;
                    case 1:
                        _color = "Green";
                        break;
                }
            }
        }

        public object GetState()
        {
            return new { Number = _number, Color = _color  };
        }

        public override string? ToString()
        {
            return $"{_number}-{_color,-7}";
        }

        public TrafficLight Clone()
        {
            return new TrafficLight(_number);
        }
    }
}
