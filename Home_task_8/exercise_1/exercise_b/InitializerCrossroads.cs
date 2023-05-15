//This class created for:
//  - initialization Controller,
//  - entering input data,
//  - creating process simulation flows and stopping them at the specified time.

//In the perspective of expanding the application, the functions of this class will be redistributed between new classes.
//In the future, the creation of such classes is planned:
//  - class for working with the "database" from which the initial data will be taken,
//  - full functional menu for interaction with the user,
//  - separate class for creating and adding methods for user notification events

using exercise_b.DataWorker;
using exercise_b.Server;

namespace exercise_b
{
    internal class InitializerCrossroads
    {
        //By default, the process simulation duration is 15 seconds
        private int _duration = 15000;

        //An initial method that accepts the simulation duration from the user and starts the simulation
        //In the future, it will be expanded for the use of individual classes
        public void Start()
        {
            bool marker = true;
            int temp = 0;
            while (marker)
            {
                try
                {
                    Console.WriteLine("Specify the duration of the process in seconds.\nIf 0 is specified, 15 seconds will be accepted by default:");
                    temp = Convert.ToInt32(Console.ReadLine());
                    if (Validator.ValidateRecord(temp))
                    {
                        _duration = temp == 0 ? _duration : temp * 1000;
                        marker = false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error happened. Please try again");
                    Console.WriteLine(ex);
                    continue;
                }
            }
            //Starts the simulation
            InitializeTraffic();
        }

        //This method executes the subscription of observers to the subject.
        //Set instructions to the subject to perform the simulation.
        //Creates, starts and stops the necessary threads for simulation
        private void InitializeTraffic()
        {
            //List of instructions to be executed by the Controller
            //One instruction has the following structure:
            //      ({first}, second, third)
            //  where:
            //      first - {the state of each traffic light at this stage} // "1" = Red, "3" = Green
            //      second - the duration of the green light period in seconds
            //      third - the duration of the yellow light period in seconds

            //In the future, this will be performed by a separate class for reading and inputting input data
            //Switching instructions for the traffic lights of the first crossroad
            List<TrafficPeriod> schedule_light_first = new List<TrafficPeriod>()
            {
                new TrafficPeriod(new int[] { 3, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 3 }, 2, 1),
                new TrafficPeriod(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 3 }, 1, 1),
                new TrafficPeriod(new int[] { 1, 1, 1, 1, 1, 3, 3, 1, 1, 3, 3, 1, 1 }, 2, 1),
                new TrafficPeriod(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 3, 1, 1 }, 2, 1),
                new TrafficPeriod(new int[] { 1, 1, 3, 3, 3, 1, 1, 3, 3, 3, 3, 3, 3 }, 2, 1),
                new TrafficPeriod(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 3, 3, 3 }, 2, 1)
            };
            //Switching instructions for the traffic lights of the second crossroad
            List<TrafficPeriod> schedule_light_second = new List<TrafficPeriod>()
            {
                new TrafficPeriod(new int[] { 3, 1, 3, 111 }, 3, 1),
                new TrafficPeriod(new int[] { 1, 3, 1, 131 }, 3, 1),
                new TrafficPeriod(new int[] { 1, 1, 1, 333 }, 3, 1),
                new TrafficPeriod(new int[] { 1, 3, 1, 311 }, 3, 1),
            };

            //Indicate the type of each traffic light for each crossroad
            List<int[]> traffic_lights_types = new List<int[]>()
            {
                new int[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                new int[] {1, 1, 1, 2}
            };


            List<List<TrafficPeriod>> periods_crossroads = new List<List<TrafficPeriod>>
            {
                schedule_light_first,
                schedule_light_second
            };

            //Creating a list of grouped traffic lights for each crossroad
            List<List<ITrafficLightObserver>> crossroads = CrossroadsGenerator(periods_crossroads, traffic_lights_types);
            //Creating a list of controllers for each crossroad
            List<Controller> controllers = ControllerGenerator(crossroads, periods_crossroads);


            //Creating a method for the event to notify the user about the current stage of the simulation.
            //Аccording to the current instruction.
            //In the future, it will be performed in a separate class.
            View.ChangingTrafficOrder += (x) =>
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                switch (x)
                {
                    case 0:
                        Console.WriteLine("Starting of the First traffic");
                        break;
                    case 1:
                        Console.WriteLine("Ending of the First traffic");
                        break;
                    case 2:
                        Console.WriteLine("Starting of the Second traffic");
                        break;
                    case 3:
                        Console.WriteLine("Ending of the Second traffic");
                        break;
                    case 4:
                        Console.WriteLine("Starting of the Third traffic");
                        break;
                    case 5:
                        Console.WriteLine("Ending of the Third traffic");
                        break;
                    default:
                        break;
                }
            };

            //Creating a thread list for each controller
            List<Thread> threads = ThreadGenerator(controllers);

            //Starting the process of transferring data to the client via NamedPipeServerStream
            ServerServices.StartServer();


            Thread.Sleep(1000);
            //Starting the threads of each controller
            StartThreads(threads);

            //Initialize the data collector 
            DataColector collector = new DataColector();
            collector.SetCrosroads(crossroads);

            //Start a separate thread for the collector
            Thread ThreadCollertor = new Thread(collector.Collector);
            ThreadCollertor.Start();

            //Stopping the main stream for the time specified by the user.
            //After that, the controller and data collector threads will be stopped
            Thread.Sleep(_duration);

            //Program execution stop of threads
            collector.RequestStop();
            StopThreads(controllers);            
        }




        private List<List<ITrafficLightObserver>> CrossroadsGenerator(List<List<TrafficPeriod>> periods_crossroads, List<int[]> traffic_lights_types)
        {
            List<List<ITrafficLightObserver>> result = new List<List<ITrafficLightObserver>>();


            for (int i = 0; i < periods_crossroads.Count; i++)
            {
                List<ITrafficLightObserver> traffic_lights_temp = new List<ITrafficLightObserver>();
                for (int j = 0; j < periods_crossroads[i][0].Ints.Length; j++)
                {
                    traffic_lights_temp.Add(new TrafficLight(j + 1, i + 1, traffic_lights_types[i][j]));
                }
                result.Add(traffic_lights_temp);
            }

            return result;
        }

        private List<Controller> ControllerGenerator(List<List<ITrafficLightObserver>> crossroads, List<List<TrafficPeriod>> periods_crossroads)
        {
            List<Controller> reuslt = new List<Controller>();

            for (int i = 0; i < crossroads.Count; i++)
            {
                Controller controller_temp = new Controller();
                controller_temp.ID = i + 1;
                controller_temp.AttachObserver(crossroads[i]);
                controller_temp.AttachSchedule(periods_crossroads[i]);
                reuslt.Add(controller_temp);
            }
            return reuslt;
        }

        private List<Thread> ThreadGenerator(List<Controller> controllers)
        {
            List<Thread> result = new List<Thread>();   
            foreach (var item in controllers)
            {
                Thread first = new Thread(item.LightFlow);

                result.Add(first);
            }
            return result;
        }
        private void StartThreads(List<Thread> threads)
        {
            foreach (var item in threads)
            {
                item.Start();
            }
        }
        private void StopThreads(List<Controller> controllers)
        {
            foreach (var item in controllers)
            {
                item.RequestStop();
            }
        }
    }
}
