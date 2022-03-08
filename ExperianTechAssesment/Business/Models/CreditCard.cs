namespace ExperianTechAssesment.Business.Models
{
    public record class CreditCard
    {
        public CreditCard(string cardName)
        {
            CardName = cardName;
        }
        public string CardName { get; }
    }
}
