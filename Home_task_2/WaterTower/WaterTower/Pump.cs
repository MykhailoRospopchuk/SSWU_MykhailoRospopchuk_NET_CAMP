namespace WaterTower
{
    internal class Pump
    {
        private bool _turn = false;
        private readonly int _power;

        public Pump(int power)
        {
            _power = power;
        }

        public int Power
        {
            get { return _power; }
        }

        public int GetWhater()
        {
            if (_turn)
            {
                return _power;
            }
            return 0;
        }
        public void TurnOnPump()
        {
            _turn = true;
        }
        public void TurnOffPump()
        {
            _turn = false;
        }
        public bool IsPumpTurn()
        { 
            return _turn; 
        }

    }
}
