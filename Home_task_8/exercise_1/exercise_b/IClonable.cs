//The interface was created to implement object cloning.
//In the case of extending or refactoring the application
namespace exercise_b
{
    internal interface IClonable<T>
    {
        T Clone();
    }
}
