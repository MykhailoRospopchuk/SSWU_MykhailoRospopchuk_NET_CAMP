namespace WaterTower
{
    internal class User
    {
        private readonly int _consumption;

        public User(int consumption)
        {
            _consumption = consumption;
        }

        public int GetConsumption()
        { 
            return _consumption; 
        }
    }
}
