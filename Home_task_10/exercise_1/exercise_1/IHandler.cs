//Interface of the link of the chain of responsibility
namespace exercise_1
{
    internal interface IHandler
    {
        IHandler SetNext(IHandler handler);
        ICard Handle(ICard request);
    }
}
