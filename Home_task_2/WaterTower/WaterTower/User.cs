namespace WaterTower
{
    internal abstract class User
    {
        private readonly int _consumption;

        public User(int consumption)
        {
            _consumption = consumption;
        }

        //Отримуємо на запит значення споживання користувача
        public abstract int GetConsumption();
        public override string ToString()
        {
            return String.Format("User consumption: {0}", _consumption);
        }
    }
}
