
namespace exercise_1
{
    internal class BaseCook : ICook
    {
        private ICook _nextHandler;

        public ICook SetNext(ICook handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual void OrderHandle(object request)
        {
            if (_nextHandler != null)
            {
                _nextHandler.OrderHandle(request);
            }
        }
    }
}
