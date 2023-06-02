
namespace exercise_1
{
    internal class ExistsBrandBankHandler : AbstractHandler
    {
        public override ICard Handle(ICard request)
        {
            if (ValidationTools.CheckCardBrand(request.CreditCardBrand))
            {
                request.IsValid = true;
                return base.Handle(request);
            }
            else
            {
                request.IsValid = false;
                return request;
            }
        }
    }
}
