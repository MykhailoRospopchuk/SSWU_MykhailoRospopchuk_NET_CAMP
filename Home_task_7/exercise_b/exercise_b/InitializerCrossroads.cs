//This class created for:
//  - initialization Controller,
//  - entering input data,
//  - creating process simulation flows and stopping them at the specified time.

//In the perspective of expanding the application, the functions of this class will be redistributed between new classes.
//In the future, the creation of such classes is planned:
//  - class for working with the "database" from which the initial data will be taken,
//  - full functional menu for interaction with the user,
//  - separate class for creating and adding methods for user notification events

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
            //      first - {the state of each traffic light at this stage} // "-1" = Red, "1" = Green
            //      second - the duration of the green light period in seconds
            //      third - the duration of the yellow light period in seconds

            //In the future, this will be performed by a separate class for reading and inputting input data
            List<TrafficPeriod> schedule_light = new List<TrafficPeriod>()
            {
                new TrafficPeriod(new int[] { 1, 1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 1, 1 }, 2, 1),
                new TrafficPeriod(new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, -1, 1, 1 }, 1, 1),
                new TrafficPeriod(new int[] { -1, -1, -1, -1, -1, 1, 1, -1, -1, 1, 1, -1, -1 }, 2, 1),
                new TrafficPeriod(new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, 1, 1, -1, -1 }, 2, 1),
                new TrafficPeriod(new int[] { -1, -1, 1, 1, 1, -1, -1, 1, 1, 1, 1, 1, 1 }, 2, 1),
                new TrafficPeriod(new int[] { -1, -1, -1, -1, -1, -1, -1, -1, -1, 1, 1, 1, 1 }, 2, 1)
            };

            //Creating a list of "TrafficLight" observers.
            //Their number corresponds to the number of traffic lights from the instructions.
            //At the moment, only one type of traffic lights is involved in the simulation.
            List<ITrafficLightObserver> traffic_lights = new List<ITrafficLightObserver>();
            for (int i = 0; i < schedule_light[0].Ints.Length; i++)
            {
                traffic_lights.Add(new TrafficLight(i + 1));
            }

            //We create an instance of the Controller subject
            Controller controller = new Controller();

            //Subscribe to the observation of observers by subject
            controller.AttachObserver(traffic_lights);
            //Set modeling instructions into the subject
            controller.AttachSchedule(schedule_light);


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

            //Creation of two streams that execute methods from the subject.

            //The first flow simulates the operation of the traffic lights at the intersection according to the specified instructions.
            Thread TrafficFlowThread = new Thread(controller.LightFlow);
            //The second thread reads data about the current state and transmits information for display to the user.
            //With an independent refresh rate, the default is 0.5 seconds
            Thread SendResultThread = new Thread(controller.SendСurrentStatus);

            
            TrafficFlowThread.Start();
            SendResultThread.Start();

            Thread.Sleep(_duration);
            
            //Stopping the execution of processes in each thread for the time specified by the user
            controller.RequestStop();
        }
    }
}
