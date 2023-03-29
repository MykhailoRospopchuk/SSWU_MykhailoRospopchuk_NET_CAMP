namespace WaterTower
{
    internal class Tower
    {
        private readonly int _max_level;
        private readonly int _min_level = 0;
        private int _current_level;

        public Tower(int max, int current_level)
        {
            _max_level = max;
            _current_level = current_level;
        }

        public void WaterIncrease(int increase)
        {
            _current_level += increase;
        }

        public void WaterDecrease(int decrease)
        {
            _current_level -= decrease;
        }

        public int GetCurrentLevel() 
        { 
            return _current_level;
        }
        public bool IsUnderMaxLevel(int pump_power)
        {
            int expected_level = _current_level + pump_power;
            if (expected_level <= _max_level)
            {
                return true;
            }
            else return false;
        }

        public bool IsOwerMinLevel(int user_consumption)
        {
            int expected_level = _current_level - user_consumption;
            if (expected_level < _min_level)
            {
                return true;
            }
            else return false;
        }
    }
}
