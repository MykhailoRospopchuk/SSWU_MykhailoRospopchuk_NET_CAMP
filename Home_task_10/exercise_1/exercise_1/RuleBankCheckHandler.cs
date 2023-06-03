//One of the links in the chain of responsibility
//Checking the card number for compliance with the specified conditions according to the card brand:
//      - number of characters and possible prefixes
namespace exercise_1
{
    internal class RuleBankCheckHandler : AbstractHandler
    {
        public override ICard Handle(ICard request)
        {
            //Call the appropriate card verification model
            if (ValidationTools.CheckCardRule(request.CreditCardBrand, request.CreditCardNumber))
            {
                request.IsValid = true;
                return base.Handle(request);
            }
            else
            {
                View.PrintErrorPoint($"{GetType().Name,-25}", request);
                request.IsValid = false;
                return request;
            }
        }
    }
}
