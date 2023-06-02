
namespace exercise_1
{
    internal class LunaHandler : AbstractHandler
    {
        public override ICard Handle(ICard request)
        {
            if (ValidationTools.LunaCheckCard(request.CreditCardNumber))
            {
                request.IsValid = true;
                return base.Handle(request);
            }
            else
            {
                View.PrintErrorPoint(this.GetType().Name, request);
                request.IsValid = false;
                return request;
            }
        }
    }
}
