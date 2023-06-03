//One of the links in the chain of responsibility
//Checks for the existence of the credit card brand in the database
namespace exercise_1
{
    internal class ExistsBrandBankHandler : AbstractHandler
    {
        public override ICard Handle(ICard request)
        {
            //Call the appropriate card verification model
            if (ValidationTools.CheckCardBrand(request.CreditCardBrand))
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
