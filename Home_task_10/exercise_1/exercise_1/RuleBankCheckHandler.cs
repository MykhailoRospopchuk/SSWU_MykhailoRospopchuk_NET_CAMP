
namespace exercise_1
{
    internal class RuleBankCheckHandler : AbstractHandler
    {
        public override ICard Handle(ICard request)
        {
            if (ValidationTools.CheckCardRule(request.CreditCardBrand, request.CreditCardNumber))
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
