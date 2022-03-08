using ExperianTechAssesment.Business.Models;

namespace ExperianTechAssesment.Business.Interfaces
{
    public interface ICreditCardOfferGenerator
    {
        IEnumerable<CreditCardOffer> GetCreditCardOffers(ApplicantRequest applicant);
    }
}
