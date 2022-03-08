namespace ExperianTechAssesment.Business.Models
{
    public class CreditCardOffer
    {
        public CreditCard Card { get; }
        public decimal  AnnualPercentageRate { get; set;}
        public string PromotionalMessage { get; set; }
        public CreditCardOffer(CreditCard card, decimal APR, string promo)
        {
            Card = card;
            AnnualPercentageRate = APR;
            PromotionalMessage = promo;
        }
    }
}
