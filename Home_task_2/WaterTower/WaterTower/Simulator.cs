using System.Text;

namespace WaterTower
{
    internal abstract class Simulator
    {
        private User _user;
        private Pump _pump;
        private Tower _tower;

        public Simulator(int consumption, int power, int max_level, int current_level)
        {
            _user = new User(consumption);
            _pump = new Pump(power);
            _tower = new Tower(max_level, current_level);
        }

        //Запускає симуляцію процесу
        public abstract void Start();

        //Контролює процес спуску і закачування води в вежу
        public abstract void ControllerLevelWater();
        
        //Організація закачки води в вежу
        public abstract void PumpWater();

        //Організація спуску води з вежі
        public abstract void GetWater();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(_user.ToString());
            sb.AppendLine(_pump.ToString());
            sb.AppendLine(_tower.ToString());
            return sb.ToString();
        }
    }
}
