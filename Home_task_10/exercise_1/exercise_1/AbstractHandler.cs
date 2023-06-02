
namespace exercise_1
{
    internal abstract class AbstractHandler : IHandler
    {
        private IHandler _next_handler;

        public IHandler SetNext(IHandler next_handler)
        {
            _next_handler = next_handler;
            return next_handler;
        }

        public virtual ICard Handle(ICard request)
        {
            if (_next_handler != null)
            {
                return _next_handler.Handle(request);
            }
            else
            {
                return request;
            }
        }
    }
}
