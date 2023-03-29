namespace WaterTower
{
    internal class Simulator
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

        public void Start()
        {
            _pump.TurnOnPump();
            Console.WriteLine("Start simulation \nPress any key to stop simulation");
            ControllerLevelWater();
            _pump.TurnOffPump();
            Console.WriteLine("End simulation");
        }

        private void ControllerLevelWater()
        {
            bool marker_pump = false;
            while (!Console.KeyAvailable)
            {
                if (_tower.IsOwerMinLevel(_user.GetConsumption()))
                {
                    marker_pump = true;
                }
                if (marker_pump)
                {
                    PumpWater();
                    if (!_tower.IsUnderMaxLevel(_pump.Power))
                    {
                        marker_pump = false;
                    }
                }
                GetWater();
                Thread.Sleep(500);
            } 
        }

        private void PumpWater()
        {
            if (_pump.IsPumpTurn())
            {
                int water = _pump.GetWhater();
                _tower.WaterIncrease(water);
                Console.WriteLine("Pump water IN Tower. Current level: {0}", _tower.GetCurrentLevel());
            }
            else
            {
                Console.WriteLine("Pump IS TURN OFF");
            }
        }

        private void GetWater()
        {
            int water = _user.GetConsumption();
            _tower.WaterDecrease(water);
            Console.WriteLine("Consumpt water FROM Tower. Current level: {0}", _tower.GetCurrentLevel());
        }
    }
}
