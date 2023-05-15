//The class performs the function of collecting information about the current state of traffic lights,
//recording data and transferring data to the console

using System.Diagnostics;
using System.Text;


namespace exercise_b.DataWorker
{
    internal class DataColector
    {
        private volatile bool _shouldStop;
        private List<List<ITrafficLightObserver>> _crossroads;
        public void RequestStop()
        {
            _shouldStop = true;
        }

        public void SetCrosroads(List<List<ITrafficLightObserver>> crossroads)
        {
            _crossroads = crossroads;
        }

        //Sends data about the current state of the Controller to the information output module.
        //In the process of scaling the application,
        //the module for outputting information about the current state can be output to a separate service.
        //In this case, the data will be sent to WPF Application via Anonymous Pipes for Local Interprocess Communication
        public void Collector()
        {
            int all_count = CountLights(_crossroads);
            dynamic[] state = new dynamic[all_count];
            int current = 0;

            StringBuilder sb = new StringBuilder();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            while (!_shouldStop)
            {
                sb.Clear();

                TimeSpan ts = stopWatch.Elapsed;
                string timer = string.Format("{0}:{1}.{2}|", ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                sb.Append(timer);

                foreach (var traffic_lights in _crossroads)
                {
                    int length = traffic_lights.Count;

                    for (int i = 0; i < length; i++)
                    {
                        sb.Append(traffic_lights[i].ToString());
                        state[current] = traffic_lights[i].GetState();
                        ++current;
                    }
                }
                View.PrintState(state, stopWatch.Elapsed);
                current = 0;
                DataHandler.SetString(sb.ToString());
                Thread.Sleep(500);
            }

        }
        private int CountLights(List<List<ITrafficLightObserver>> crossroads)
        {
            int count = 0;
            foreach (var item in crossroads)
            {
                foreach (var item1 in item)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
