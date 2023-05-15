// Traffic lights act as observers of changes in the state of the subject - the Traffic Controller.
// Since the type of traffic lights may change or new ones may be created in the future.
// We use the interface to set the general behavior of the traffic light
namespace exercise_b
{
    internal interface ITrafficLightObserver
    {
        int Type
        {
            get;
        }
        // Receive update from subject
        // Using the Update method, the status of the traffic light is updated according to the received value of the subject's state
        Task UpdateAsync(int value, int second);

        object GetState();

        string? ToString();
    }
}