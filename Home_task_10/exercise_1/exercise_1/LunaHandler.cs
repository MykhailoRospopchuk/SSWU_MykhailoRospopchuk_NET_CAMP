//One of the links in the chain of responsibility
//Verification of the card number by the Luna algorithm
namespace exercise_1
{
    internal class LunaHandler : AbstractHandler
    {
        public override ICard Handle(ICard request)
        {
            //Call the appropriate card verification model
            if (ValidationTools.LunaCheckCard(request.CreditCardNumber))
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
