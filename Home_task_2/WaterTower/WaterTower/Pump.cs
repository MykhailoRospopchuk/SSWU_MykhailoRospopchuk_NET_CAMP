using System.Text;

namespace WaterTower
{
    internal abstract class Pump
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

        //Закачує воду величиною з його потужність
        public abstract int GetWhater();

        //Вмикає насос
        public abstract void TurnOnPump();

        //Вимикає насос
        public abstract void TurnOffPump();

        //Перевіряє чи насос увімкнено
        public abstract bool IsPumpTurn();

        public override string ToString()
        {
            return String.Format("Pump is turn? - {0}. Power of Pump - {1}", _turn, _power);
        }

    }
}
