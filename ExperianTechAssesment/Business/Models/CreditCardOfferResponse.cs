namespace ExperianTechAssesment.Business.Models
{
    public class CreditCardOfferResponse
    {
        public IEnumerable<CreditCardOffer> Offers { get; }
        public string Message { get { return Offers.Count() > 0 ? "Offers available" : "No offers available"; } }
        public CreditCardOfferResponse(IEnumerable<CreditCardOffer> offers) : base()
        {
            Offers = offers;
        }
    }
}
