namespace WaterTower
{
    internal abstract class Tower
    {
        private readonly int _max_level;
        private readonly int _min_level = 0;
        private int _current_level;

        public Tower(int max, int current_level)
        {
            _max_level = max;
            _current_level = current_level;
        }

        //Збільшує рівень води в вежі на  велечину increase
        public abstract void WaterIncrease(int increase);

        //Зменшуємо рівень води в вежі на  велечину increase
        public abstract void WaterDecrease(int decrease);

        //Повертає на запит поточний ірвень води в вежі
        public abstract int GetCurrentLevel();

        //Перевіряє чи поточний рівень води + об'єм води закачики не буде перевищувати максимальний рівень води
        public abstract bool IsUnderMaxLevel(int pump_power);

        //Перевіряє чи поточний рівень води - об'єм води споживання не буде меншим за мінімальний рівень води
        public abstract bool IsOwerMinLevel(int user_consumption);

        public override string ToString()
        {
            return String.Format("Max level of water: {0}. Min level of water: {1}. Current level of water: {2}", _max_level, _min_level, _current_level);
        }
    }
}
