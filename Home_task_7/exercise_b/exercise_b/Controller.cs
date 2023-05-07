//The Controller class acts as a subject in the Observer pattern.
//The Controller executes the subscription of TrafficLights observers.
//Accepts instructions according to which the behavior of the Controller must be carried out.

using System.Diagnostics;

namespace exercise_b
{
    internal class Controller : ISubject
    {
        private List<TrafficPeriod> _schedule_light = new List<TrafficPeriod>();

        private List<ITrafficLightObserver> _traffic_lights = new List<ITrafficLightObserver>();

        private volatile bool _shouldStop;

        public void RequestStop()
        {
            _shouldStop = true;
        }

        public void AttachObserver(List<ITrafficLightObserver> observer)
        {
            Console.WriteLine("Subjects: Attached an observer.");
            _traffic_lights.AddRange(observer);
        }

        public void AttachSchedule(List<TrafficPeriod> schedule_light)
        {
            Console.WriteLine("Suchedules: Attached an schedule light.");
            _schedule_light.AddRange(schedule_light);
        }

        public void Detach(ITrafficLightObserver observer)
        {
            _traffic_lights.Remove(observer);
            Console.WriteLine("Subject: Detached an observer.");
        }

        //Notifies observers of a change in its state.
        public void Notify(int[] income_arr, int yellow_Period)
        {
            for (int i = 0; i < income_arr.Length; i++)
            {
                _traffic_lights[i].Update(income_arr[i], yellow_Period);
            }
        }

        //Performs the process of simulating the operation of traffic lights at the intersection.
        public void LightFlow()
        {
            while (!_shouldStop)
            {
                Console.WriteLine("Subject: One traffic change cycle completed...");

                for (int k = 0; k < _schedule_light.Count; k++)
                {
                    if (_shouldStop)
                        break;

                    int[] arr = _schedule_light[k].Ints;

                    View.PrintChangeState(k);

                    Notify(arr, _schedule_light[k].YellowPeriod);
                    
                    Thread.Sleep(_schedule_light[k].Period);
                }
            }
        }

        //Sends data about the current state of the Controller to the information output module.
        //In the process of scaling the application,
        //the module for outputting information about the current state can be output to a separate service.
        //In this case, the data will be sent in json format
        public void SendСurrentStatus()
        {
            int length = _traffic_lights.Count;
            dynamic[] state = new dynamic[length];

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            while (!_shouldStop)
            {
                for (int i = 0; i < length; i++)
                {
                    state[i] = _traffic_lights[i].GetState();
                }
                View.PrintState(state, stopWatch.Elapsed);
                Thread.Sleep(500);
            }

            Console.ForegroundColor = ConsoleColor.White;
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine(ts);
        }
    }
}
