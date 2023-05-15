// Traffic lights act as observers of changes in the state of the subject - the Traffic Controller.
// Since the type of traffic lights may change or new ones may be created in the future.
// We use the interface to set the general behavior of the subject Controller
namespace exercise_b
{
    internal interface ISubject
    {
        // Attach an observer to the subject.
        void AttachObserver(List<ITrafficLightObserver> observer);
        // Attach an schedule to the subject.
        void AttachSchedule(List<TrafficPeriod> schedule_light);

        // Detach an observer from the subject.
        void Detach(ITrafficLightObserver observer);

        // Notify all observers about an event.
        // Use the Notify method to notify observers of a change in the subject's state
        void Notify(int[] income_arr, int yellow_Period);
    }
}
