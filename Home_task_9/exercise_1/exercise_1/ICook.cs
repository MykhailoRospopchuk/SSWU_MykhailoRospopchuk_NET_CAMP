
namespace exercise_1
{
    internal interface ICook
    {
        ICook SetNext(ICook cook);

        void OrderHandle(object request);
    }
}
